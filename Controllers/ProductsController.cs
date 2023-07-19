using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DbFiles;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContextFile _context;
        private IWebHostEnvironment webHost;
        public ProductsController(MyDbContextFile context, IWebHostEnvironment webHost)
        {
            _context = context;
            this.webHost = webHost;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var myDbContextFile = _context.products.Include(p => p.Category);
            return View(await myDbContextFile.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.categories, "CategoryId", "CName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product , IFormFile Img)
        {
            if(Img != null)
            {
                string ext = Path.GetExtension(Img.FileName);
                if(ext==".jpg"|| ext==".png" || ext == ".gif")
                {
                    string dt = Path.Combine(webHost.WebRootPath, "assets/img");
                    string FName = Path.GetFileName(Img.FileName);
                    string FPath = Path.Combine(dt, FName);

                    using (var fs = new FileStream(FPath,FileMode.Create) ) {
                        await Img.CopyToAsync(fs);
                    }
                    product.PImage = @"/assets/img/" + FName;
                }
                else
                {
                    ViewBag.error = "Please selected File images";
                }
            }
            
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.categories, "CategoryId", "CName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["Category"] = new SelectList(_context.categories, "CategoryId", "CName", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage(int id, Product product, IFormFile Img)
        {
            if (Img != null)
            {
                string ext = Path.GetExtension(Img.FileName);
                if (ext == ".jpg" || ext == ".png" || ext == ".gif")
                {
                    string dt = Path.Combine(webHost.WebRootPath, "assets/img");
                    string FName = Path.GetFileName(Img.FileName);
                    string FPath = Path.Combine(dt, FName);

                    using (var fs = new FileStream(FPath, FileMode.Create))
                    {
                        await Img.CopyToAsync(fs);
                    }
                    product.PImage = @"/assets/img/" + FName;
                }
                else
                {
                    ViewBag.error = "Please selected File images";
                }
            }

            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'MyDbContextFile.products'  is null.");
            }
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
