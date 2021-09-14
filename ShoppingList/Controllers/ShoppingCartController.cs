using Microsoft.AspNetCore.Mvc;
using ShoppingList.Dal;
using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Core.Repositories;
using ShoppingList.Core.Services;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ShoppingList.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _svc;
        private readonly INotyfService _notyf;

        public ShoppingCartController(IShoppingCartService svc, INotyfService notyf)
        {
            _svc = svc;
            _notyf = notyf;

        }
        public async Task<IActionResult> IndexAsync()
        {
            //var randomVarijabla = await _svc.GetShoppingCartWithProducts(1);
            return View(await _svc.GetAll());
        }

        //GET-Create -> korisnik upisuje stoga nema potrebe za davanjem objekta baze
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create -> ovaj puta trebamo db objekt jer postamo u database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)//validate data with annotations
            {
                var added = await _svc.Add(shoppingCart);
                if (added)//check date with services
                {
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
        //GET - Edit
        public async Task<IActionResult> EditAsync(int? id)
        {
            if(id == null || id == 0)
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
