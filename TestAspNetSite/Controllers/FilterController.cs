using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAspNetSite.Models;
using Microsoft.EntityFrameworkCore;
namespace TestAspNetSite.Controllers
{
    public class FilterController : HomeController
    {
        public List<Product> SearchList { get; set; }
        public IProductRepository Repository { get; set; }
        public FilterController(IProductRepository repository)
            :base(repository)
        {
            Repository = repository;
            SearchList = new List<Product>();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Filter());
        }
        [HttpPost]
        public IActionResult Index(Filter filter)
        {
            foreach (var i in Repository.Products)
            {
                if (filter.Name == i.Name)
                {
                    TempData["state"] = "По вашему запросу был обнаружен фильм с тем же названием";
                    SearchList.Add(i);
                    return View("Search",SearchList);
                }
            }
            foreach (var i in Repository.Products)
            {
                if (i.Name.Contains(filter.Name,StringComparison.OrdinalIgnoreCase))
                {
                    SearchList.Add(i);
                }
            }
            if (SearchList.Count == 0)
            {
                TempData["state"] = "Фильмов не обнаружено, проверьте правильность или данного фильма нет на сайте,обратитесь к администрации";
                return View("Index");
            }
            else
            {
                TempData["state"] = "Фильма нет в списке, проверьте правильность набора или посмотрите их в похожих фильмах." ;
                return View("Search",SearchList);
            }
        }
        public IActionResult Search()
        {
            return View(SearchList);
        }
    }
}
