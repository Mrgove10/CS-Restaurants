using Grestau.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        /// <summary>
        /// Get Create page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// post create page
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="adress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("Name,Phone,Description,Email")] Restaurant restaurant,
            [Bind("Numero,Rue,CodePostal,Ville")] Adress adress
        )
        {
            if (ModelState.IsValid)
            {
                _restaurantService.AddRestaurant(restaurant);

                _adressService.AddAdress(restaurant, adress);

                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }
    }
}