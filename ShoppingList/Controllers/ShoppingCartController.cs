using Microsoft.AspNetCore.Mvc;
using ShoppingList.Dal;
using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.Core.Repositories;
using ShoppingList.Core.Services;

namespace ShoppingList.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _svc;

        public ShoppingCartController(IShoppingCartService svc)
        {
            _svc = svc;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var randomVarijabla = await _svc.GetShoppingCartWithProducts(1);
            return View(await _svc.GetAll());
        }

        //GET-Create -> korisnik upisuje stoga nema potrebe za davanjem objekta baze
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create -> ovaj puta trebamo db objekt jer postamo u database
        [HttpPost]
        [ValidateAntiForgeryToken]//appenda AntiForgeryToken koji se provjerava na postanju dali je još uvijek valid i da security nije breachan
        public async Task<IActionResult> CreateAsync(ShoppingCart obj)
        {
            var added = await _svc.Add(obj);
            //ISPISI PORUKU GRESKE AKO JE svc.Add(obj) FALSE
            if (added)
            {
                return RedirectToAction("Index");
            }
            else return RedirectToAction("Create");


        }
    }
}
