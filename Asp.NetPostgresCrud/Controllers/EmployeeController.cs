using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.NetPostgresCrud.Models;
using Microsoft.AspNetCore.DataProtection;

namespace Asp.NetPostgresCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        private readonly IDataProtector _protector;


        public EmployeeController(EmployeeContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector("Your_Key");

        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var temp = await _context.Employees.ToListAsync();
            foreach (var s in temp)
            {
                s.EmpCode = _protector.Unprotect(s.EmpCode);
            }
            return View(temp);
        }



        // GET: Employee/Create
        public IActionResult AddorEdit(int id = 0)
        {

            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                var test = _context.Employees.Find(id);
                test.EmpCode = _protector.Unprotect(test.EmpCode);
                return View(test);
            }
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("EmployeeID,FullName,EmpCode,Position,OfficeLocation")] Employee employee)
        {
            string text = employee.EmpCode;
            employee.EmpCode = _protector.Protect(text);
            if (ModelState.IsValid)
            {
                if (employee.EmployeeID == 0)
                {

                    _context.Add(employee);
                }
                else
                {
                    _context.Update(employee);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }



        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
