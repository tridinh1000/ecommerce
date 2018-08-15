using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductController : Controller{
        private EcommerceContext _context;
        public ProductController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products()
        {
            ViewBag.products = _context.products.ToList();
            return View("Products");
        }

        [HttpPost]
        public IActionResult CreateProduct(Product p)
        {
            if(ModelState.IsValid){
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            else{
                return View("Products");
            }
        }
    }
}