using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantById((Guid) id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        
        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,
            [Bind("ID,Name,Phone,Description,Email")] Restaurant restaurant,
            [Bind("Numero,Rue,Ville,CodePostal")] Adress adress
        )
        {
            if (id != restaurant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //  _restaurantService.UpdateRestaurant(restaurant);
                    if (restaurant.Adress == null)
                    {
                        // here we do not do rating.ID = Guid.NewGuid(); because it is generated automaticly when added
                        adress.ID = new Guid();
                        _adressService.AddAdress(restaurant, adress);
                    }
                    else
                    {
                        _restaurantService.UpdateRestaurant(restaurant);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.ID))
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

            return View(restaurant);
        }
        
        
    }
}