using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AhmerMYWebDemo.Models;

namespace AhmerMYWebDemo.Controllers
{
    public class ESalariesController : Controller
    {
        private readonly MyDbContext _context;

        public ESalariesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ESalaries
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Salary.Include(e => e.Employees);
            return View(await myDbContext.ToListAsync());
        }
        //public  IActionResult Index()
        //{
        //    var sumOfSalray  = 

        //    return View();
        //}

        // GET: ESalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var eSalary = await _context.Salary
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSalary == null)
            {
                return NotFound();
            }

            return View(eSalary);
        }

        // GET: ESalaries/Create
        public IActionResult Create()
        {
            ViewData["EmployeesId"] = new SelectList(_context.ObjEmployees, "E_Id", "E_Name");
            return View();
        }

        // POST: ESalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EMonth,Edate,EAmount,EmployeesId")] ESalary eSalary)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(eSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["EmployeesId"] = new SelectList(_context.ObjEmployees, "E_Id", "E_Name", eSalary.EmployeesId);
            return View(eSalary);
        }

        // GET: ESalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var eSalary = await _context.Salary.FindAsync(id);
            if (eSalary == null)
            {
                return NotFound();
            }
            ViewData["EmployeesId"] = new SelectList(_context.ObjEmployees, "E_Id", "E_Name", eSalary.EmployeesId);
            return View(eSalary);
        }

        // POST: ESalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EMonth,Edate,EAmount,EmployeesId")] ESalary eSalary)
        {
            if (id != eSalary.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(eSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ESalaryExists(eSalary.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["EmployeesId"] = new SelectList(_context.ObjEmployees, "E_Id", "E_Name", eSalary.EmployeesId);
            //return View(eSalary);
        }

        // GET: ESalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salary == null)
            {
                return NotFound();
            }

            var eSalary = await _context.Salary
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eSalary == null)
            {
                return NotFound();
            }

            return View(eSalary);
        }

        // POST: ESalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salary == null)
            {
                return Problem("Entity set 'MyDbContext.Salary'  is null.");
            }
            var eSalary = await _context.Salary.FindAsync(id);
            if (eSalary != null)
            {
                _context.Salary.Remove(eSalary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ESalaryExists(int id)
        {
          return (_context.Salary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
