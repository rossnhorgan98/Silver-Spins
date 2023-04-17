using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS4439_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS4439_Assignment.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            DB db = DB.Retrieve();
            List<Album> albumList = db.albums;
            ViewBag.albumList = albumList;

            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult OrderView()
        {
            DB db = DB.Retrieve();
            List<Order> orderList = db.orders;
            ViewBag.Orders = orderList;

            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            DB db = DB.Retrieve();
            List<Album> albumList = db.albums;
            ViewBag.albumList = albumList;

            if (ModelState.IsValid) {

                //Giving the orderID a unique id number
                Random getId = new Random();
                int orderId = getId.Next(1, 9999);
                order.OrderID = orderId;

                DB.AddOrder(order);
                return View(order);
            }
            else
                return View();

        }

        [HttpPost]
        public IActionResult LogIn(LogInViewModel user)
        {
            if (user.Email == "admin1@gmail.com" && user.Password == "pass")
            {
                DB db = DB.Retrieve();
                List<Order> orderList = db.orders;
                ViewBag.Orders = orderList;

                return View("OrderView");
            }
            else
            {
                ViewBag.message = "Incorrect email or password";
                return View();
            }

        }
    }
}
