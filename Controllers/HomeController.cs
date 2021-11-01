using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assessment5a.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assessment5a.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculator()
        {
            
            return View("Calculator");
        }
        public IActionResult Result([Bind("num1", "num2", "operation")] Calculator newCalc)
        //public IActionResult Result(double num1, double num2, string operation)
        {
            double result = 0;
            switch (newCalc.operation)
            {
                
                case "Plus":
                   result = newCalc.num1 + newCalc.num2;
                break;
                case "Minus":
                   result = newCalc.num1 - newCalc.num2;
                break;
                case "Multiply":
                    result = newCalc.num1 * newCalc.num2;
                    break;
                case "Divide":
                    result = newCalc.num1 / newCalc.num2;
                    break;

            default:
                    break;
        }

        
            ViewBag.Result = result;
            ViewBag.Operation = newCalc.operation;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
