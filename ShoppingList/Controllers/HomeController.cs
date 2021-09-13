using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingList.Dal;
using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
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
            //using (var context = new ShoppingListDatabaseContext())
            //{
                //var products = context.Products.Where(e => e.Name.Contains("Burek")).ToList();
                //context.Products.Add(new Product() { Price = 28, Name = "Kebab", Description = "S lukom i blagim umakom", IsChecked = false });
                //context.SaveChanges();

                //var product = context.Products.Where(x => x.Name == "Kebab").FirstOrDefault();
                //if(product != null)
                //{
                //    product.Price += 1;
                //    context.SaveChanges();
                //    Console.WriteLine($"Cijena kebaba je: {product.Price}");
                //}

                //foreach (var product in products)
                //{
                //    product.Price += 1;
                //    _logger.LogInformation($"Cijena bureka {product.Description} je: {product.Price} ");
                //}
                //context.SaveChanges();

            //    var shoppingList = context.ShoppingCart.Where(x => x.Id == 1).Include(x => x.ShoppingListProducts).FirstOrDefault();
            //    Console.WriteLine("Test");

            //    foreach (var item in shoppingList.ShoppingListProducts)
            //    {
            //        _logger.LogInformation($"U itemu ima {item}.");
            //    }

            //}
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
