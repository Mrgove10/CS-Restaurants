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
        public IActionResult Rating(Guid? id)
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
        /// POst rating
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rating(
            [Bind("ID")] Restaurant restaurant,
            [Bind("ID,Date,Stars,Comment")] Rating rating
        )
        {
            var r = _restaurantService.GetRestaurantById(restaurant.ID);

            if (r.Rating == null)
            {
                _ratingService.AddRating(restaurant, rating);
            }
            else
            {
                _ratingService.UpdateRating(rating);
            }

            return View(r);
        }
    }
}