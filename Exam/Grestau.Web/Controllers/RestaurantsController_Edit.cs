using System;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        /// <summary>
        /// Get edit page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetRestaurantById((Guid) id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        /// <summary>
        /// Post edit page
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurant"></param>
        /// <param name="adress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,
            [Bind("ID,Name,Phone,Description,Email")] Restaurant restaurantform,
            [Bind("Numero,Rue,Ville,CodePostal")] Adress adress
        )
        {
            var restaurantorg = _restaurantService.GetRestaurantById(id);
            if (id != restaurantorg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //  _restaurantService.UpdateRestaurant(restaurant);
                    if (restaurantorg.Adress == null)
                    {
                        // here we do not do rating.ID = Guid.NewGuid(); because it is generated automaticly when added
                        adress.ID = new Guid();
                        _adressService.AddAdress(restaurantform, adress);
                    }
                    else
                    {
                        restaurantform.Adress = restaurantorg.Adress;
                        restaurantform.Rating = restaurantform.Rating;
                        _restaurantService.UpdateRestaurant(restaurantform);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurantform.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(restaurantform);
        }
    }
}