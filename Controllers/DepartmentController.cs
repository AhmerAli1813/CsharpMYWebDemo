using AhmerMYWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AhmerMYWebDemo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index() {
            var depData = _context.Department.Include(e =>e.Employees);
            return View(await depData.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["EmpData"] = new SelectList(_context.ObjEmployees, "E_Id", "E_Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departments dep)
        {
            _context.Add(dep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
        }
    }
}
