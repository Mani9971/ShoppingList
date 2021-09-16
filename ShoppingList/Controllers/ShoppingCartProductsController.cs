using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Core.Services;
using ShoppingList.Core.Models;
using System;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;

namespace ShoppingList.Controllers
{
    public class ShoppingCartProductsController : Controller
    {
        private readonly IShoppingCartService _svc;
        private readonly IProductService _psvc;
        private readonly INotyfService _notyf;
        private ISession _session;

        public ShoppingCartProductsController(IShoppingCartService svc, INotyfService notyf, IProductService psvc, IHttpContextAccessor httpContextAccessors)
        {
            _svc = svc;
            _psvc = psvc;
            _notyf = notyf;
            _session = httpContextAccessors.HttpContext.Session;

        }

        public async Task<IActionResult> IndexAsync(int? id)
        {
            if(id != 0 && id != null)
            {
                _session.SetInt32("_Id", (int)id);
                int storedId = (int)_session.GetInt32("_Id");
                ShoppingCartProducts shoppingCart = new();
                shoppingCart.ShoppingCart = await _svc.GetShoppingCartWithProducts(storedId);
                return View(shoppingCart);
            }
            return RedirectToAction("Index", new { id = (int)_session.GetInt32("_Id")});
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexPostAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                var updated = await _svc.AddProductToShoppingCart(product, (int)_session.GetInt32("_Id"));
                if (updated != null)
                {
                    _notyf.Warning("Product Added.");
                    return RedirectToAction("Index");
                }
            }
            _notyf.Warning("Invalid information entered.");
            return RedirectToAction("Index");
        }

    }
}
