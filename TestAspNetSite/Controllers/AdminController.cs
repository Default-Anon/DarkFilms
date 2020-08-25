using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAspNetSite.Models;

namespace TestAspNetSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository { get; set; }
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Products);
        [HttpGet]
        public ViewResult Edit(int ProductId)
            => View(repository.Products.FirstOrDefault(p => p.ProductId == ProductId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["mesasage"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public ViewResult Create()
            => View("Edit", new Product());
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Edit(product);
            return RedirectToAction("Index");
        }
    }
}
