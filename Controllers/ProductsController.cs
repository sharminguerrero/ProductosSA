using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosSA.Data;
using ProductosSA.Entities;
using ProductosSA.Models;
using System.Threading.Tasks;

namespace ProductosSA.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id, Descripción, Costo, Precio, Estado")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Products obj = new Products();
                obj.Description = product.Descripción;
                obj.Cost = product.Costo;
                obj.Price = product.Precio;
               // obj.State = product.Estado;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]

        public async Task <IActionResult> Edit (int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            var model = new ProductViewModel();
            {
                model.Id = product.Id;
                model.Precio = product.Price;
                //model.Estado = product.State;
                model.Costo = product.Cost;
                model.Descripción = product.Description;
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id,[Bind("Id, Descripción, Costo, Precio, Estado")] ProductViewModel product)
        {

            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var obj = new Products();
                {
                    obj.Id = product.Id;
                    obj.Description = product.Descripción;
                    obj.Cost = product.Costo;
                    obj.Price = product.Precio;
                   // obj.State = product.Estado;
                };
                _context.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete (int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
