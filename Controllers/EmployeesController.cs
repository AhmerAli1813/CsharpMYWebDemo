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
    public class EmployeesController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return _context.ObjEmployees != null ? 
                          View(await _context.ObjEmployees.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.ObjEmployees'  is null.");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ObjEmployees == null)
            {
                return NotFound();
            }

            var employees = await _context.ObjEmployees
                .FirstOrDefaultAsync(m => m.E_Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("E_Id,E_Name,E_Email,E_Password,E_Address,E_ConfirmPassword")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ObjEmployees == null)
            {
                return NotFound();
            }

            var employees = await _context.ObjEmployees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("E_Id,E_Name,E_Email,E_Password,E_Address,E_ConfirmPassword")] Employees employees)
        {
            if (id != employees.E_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.E_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ObjEmployees == null)
            {
                return NotFound();
            }

            var employees = await _context.ObjEmployees
                .FirstOrDefaultAsync(m => m.E_Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ObjEmployees == null)
            {
                return Problem("Entity set 'MyDbContext.ObjEmployees'  is null.");
            }
            var employees = await _context.ObjEmployees.FindAsync(id);
            if (employees != null)
            {
                _context.ObjEmployees.Remove(employees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
          return (_context.ObjEmployees?.Any(e => e.E_Id == id)).GetValueOrDefault();
        }
    }
}
