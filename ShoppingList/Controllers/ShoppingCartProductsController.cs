using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Models;
using ShoppingList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Controllers
{
    public class ShoppingCartProductsController : Controller
    {
        private readonly IShoppingCartService _svc;
        private readonly INotyfService _notyf;

        public ShoppingCartProductsController(IShoppingCartService svc, INotyfService notyf)
        {
            _svc = svc;
            _notyf = notyf;

        }

        public async Task<IActionResult> IndexAsync(int? id)
        {
            if(id != null) {
                var shoppingCart = await _svc.GetShoppingCartWithProducts((int)id);
                ViewBag.ShoppingCartWithProducts = shoppingCart;
                return View();
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexPostAsync(Product product)
        {
            //if (ModelState.IsValid)//validate data with annotations
            //{
            //    var added = await _svc.Kako sad omoguciti dodavanje u pomocnu tablicu??
            //        if (added)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        _notyf.Warning("Invalid information entered.");
            //        return RedirectToAction("Index");

            //    }
            //}
            //_notyf.Warning("Invalid information entered.");
            //return RedirectToAction("Index");
            return null;//added extra-delete later
        }
        //GET - Edit
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null || id == 0)
            {
                _notyf.Error("List not found.");
                return View();
            }
            var shoppingCart = await _svc.Get((int)(id!));
            if (shoppingCart != null)
            {
                return View(shoppingCart);
            }
            return View();
        }

        //POST-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                var updated = await _svc.Update(shoppingCart);
                if (updated)
                {
                    _notyf.Success("List updated.");
                    return RedirectToAction("Index");
                }
                else
                {
                    _notyf.Warning("Please select a valid date.");
                    return View(shoppingCart);
                }
            }
            return View(shoppingCart);
        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePostAsync(int? id)
        {
            var deleted = await _svc.Delete((int)(id));
            if (deleted)
            {
                _notyf.Success("List deleted.");
                return RedirectToAction("Index");
            }
            else
            {
                _notyf.Warning("List not found.");
                return RedirectToAction("Index");
            }
        }
    }
}
