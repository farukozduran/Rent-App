using Microsoft.AspNetCore.Mvc;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class CarsController : Controller
    {
        public readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Cars.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Cars.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            _context.Update(car);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Cars.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id, Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
