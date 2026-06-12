using Microsoft.AspNetCore.Mvc;
using Rent.App.Models;

namespace Rent.App.Controllers
{
    public class CustomersController : Controller
    {
        public readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Customers.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _context.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id, Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
