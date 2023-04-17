using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS4439_Assignment.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Http(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }
    }
}
