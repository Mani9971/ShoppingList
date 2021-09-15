using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Models;
using ShoppingList.Core.Repositories;
using ShoppingList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IProductService _svc;

        public ProductController(INotyfService notyf, IProductService svc)
        {
            _notyf = notyf;
            _svc = svc;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _svc.GetAll();
            ViewBag.Products = products;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexPostAsync(Product product)
        {
            if (ModelState.IsValid)//validate data with annotations
            {
                var added = await _svc.Add(product);
                if (added)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyf.Warning("Invalid information entered.");
                    return RedirectToAction("Index");

                }
            }
            _notyf.Warning("Invalid information entered.");
            return RedirectToAction("Index");
        }

        //GET - Edit
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null || id == 0)
            {
                _notyf.Error("Product not found.");
                return View();
            }
            var product = await _svc.Get((int)(id!));
            if (product != null)
            {
                return View(product);
            }
            return View();
        }

        //POST-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                var updated = await _svc.Update(product);
                if (updated)
                {
                    _notyf.Success("Product updated.");
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            return View(product);
        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePostAsync(int? id)
        {
            var deleted = await _svc.Delete((int)(id));
            if (deleted)
            {
                _notyf.Success("Product deleted.");
                return RedirectToAction("Index");
            }
            else
            {
                _notyf.Warning("Product not found.");
                return RedirectToAction("Index");
            }
        }
    }
}
