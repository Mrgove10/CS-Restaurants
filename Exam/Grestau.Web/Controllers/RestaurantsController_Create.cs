using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        public IActionResult Create()
        {
            return View();
        }


        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("Name,Phone,Description,Email")] Restaurant restaurant,
            [Bind("Numero,Rue,CodePostal,Ville")] Adress adress
        )
        {
            if (ModelState.IsValid)
            {
                //restaurant.ID = Guid.NewGuid();
                _restaurantService.AddRestaurant(restaurant);

                _adressService.AddAdress(restaurant, adress);

                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }
    }
}