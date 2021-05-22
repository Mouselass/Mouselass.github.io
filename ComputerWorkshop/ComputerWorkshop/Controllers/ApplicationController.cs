using ComputerWorkshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWorkshop.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Index(string problemInput, string contactInput)
        {
            if (problemInput != null && problemInput.Length >= 30 && contactInput != null)
            {
                Response.Redirect("../Home/Index");
            }
            else
            {
                Response.Redirect("Application/Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
