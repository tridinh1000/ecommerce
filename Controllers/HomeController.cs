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
    public class HomeController : Controller
    {
        private EcommerceContext _context;
        public HomeController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.products = _context.products.ToList();
            ViewBag.orders = _context.orders.Include(p => p.product).Include(c => c.customer).OrderByDescending(q => q.created_at).ToList();
            ViewBag.customers = _context.customers.ToList();
            return View();
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Customers()
        {
            ViewBag.customers = _context.customers.ToList();
            ViewBag.customerError = TempData["noCustomerName"];
            return View("Customers");
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer c)
        {
            if(ModelState.IsValid){
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Customers");
            }
            else {
                TempData["noCustomerName"] = "Provide customer name";
                return RedirectToAction("Customers");
            }
        }

        [HttpGet]
        [Route("/customer/delete/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer c = _context.customers.SingleOrDefault(x => x.customerid == id);
            _context.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }


    }
}
