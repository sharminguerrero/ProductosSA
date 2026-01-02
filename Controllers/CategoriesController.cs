using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosSA.Data;
using ProductosSA.Entities;
using ProductosSA.Models;
using System.Threading.Tasks;

namespace ProductosSA.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Add ([Bind("Id, Name, IsActive ")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                Categories obj = new Categories();
                obj.Name = category.Name;
                obj.IsActive = category.IsActive;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            var model = new CategoryViewModel();
            {
                model.Id = category.Id;
                model.Name = category.Name;
                model.IsActive = category.IsActive;
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("Id, Nombre, EstaActivo")] CategoryViewModel category)
        {
            if (id != category.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var obj = new Categories();
                {
                    obj.Name = category.Name;
                    obj.IsActive = category.IsActive;
                }
                _context.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
