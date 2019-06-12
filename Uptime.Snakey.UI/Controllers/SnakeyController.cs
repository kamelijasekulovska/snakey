using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uptime.Snakey.UI.Models;

namespace Uptime.Snakey.UI.Controllers
{
    public class SnakeyController : Controller
    {
        public IActionResult Index()
        {
            //GET RssFeed from Uptime.Snakey.Service
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
