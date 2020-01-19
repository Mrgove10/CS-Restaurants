using System;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        /// <summary>
        /// Get Rating
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Rating(Guid? id)
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
        
        /// <summary>
        /// POst rating
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rating(
            [Bind("ID")] Restaurant restaurant,
            [Bind("ID,Date,Stars,Comment")] Rating rating
        )
        {
            var r = await _restaurantService.GetRestaurantById(restaurant.ID);

            if (r.Rating == null)
            {
                // here we do not do rating.ID = Guid.NewGuid(); because it is generated automaticly when added
                _ratingService.AddRating(restaurant, rating);
            }
            else
            {
                _ratingService.UpdateRating(rating);
            }

            return View();
        }
    }
}