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
        public async Task<IActionResult> Add([Bind("Id, Descripción, Costo, Precio, Estado")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Products obj = new Products();
                obj.Description = product.Descripción;
                obj.Cost = product.Costo;
                obj.Price = product.Precio;
                obj.State = product.Estado;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
