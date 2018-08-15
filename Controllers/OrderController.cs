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
    public class OrderController : Controller{
        private EcommerceContext _context;
        public OrderController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Orders()
        {
            ViewBag.customers = _context.customers.ToList();
            ViewBag.products = _context.products.ToList();
            ViewBag.error = TempData["suckit"];
            List<Order> orders = _context.orders.Include(c => c.customer).Include(p => p.product).ToList();
            return View("Orders", orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(int customerid, int productid, int quantity)
        {
            Product prod = _context.products.SingleOrDefault(p => p.productid == productid);
            if (prod.quantity < quantity){
                TempData["suckit"] = "Nice try dickhead";
                return RedirectToAction("Orders");
            }
            else {
                prod.quantity -= quantity;
                Order order= new Order();
                order.customerid = customerid;
                order.productid = productid;
                order.quantity = quantity;
                _context.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
        }
    }
}