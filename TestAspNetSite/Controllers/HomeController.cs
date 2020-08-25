using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAspNetSite.Models;

namespace TestAspNetSite.Controllers
{
    public class HomeController : Controller
    {
        public IProductRepository repository { get; set; }
        public HomeController(IProductRepository repos)
        {
            repository = repos;
        }
        public IActionResult Index()
        {
            return View(repository);
        }
    }
}
