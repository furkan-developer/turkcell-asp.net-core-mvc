using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var data = _db.Products.ToList();
            return View(data);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            var data = _db.Products.FirstOrDefault(p => p.Id.Equals(id));
            return View(data);
        }
    }
}