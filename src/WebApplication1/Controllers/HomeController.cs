using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private INodeServices nodeServices;

        public HomeController(INodeServices nodeServices)
        {
            this.nodeServices = nodeServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult TonyAction()
        {
            // return View("About");
            var result = nodeServices.InvokeAsync<Stream>("imageresizer.js", "diagram.jpg", 300);
            return File(result.Result, "image/jpeg");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
