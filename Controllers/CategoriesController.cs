using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosSA.Data;
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
    }
}
