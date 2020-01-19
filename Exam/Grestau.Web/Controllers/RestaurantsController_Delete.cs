using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        /// <summary>
        /// Get delete page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
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
        /// Post delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var restaurantList = await _restaurantService.GetAllRestaurant();
            var restaurant = restaurantList.Find(m => m.ID == id);

            _restaurantService.DeleteRestaurant(restaurant);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(Guid id)
        {
            return _restaurantService.GetAllRestaurant().Result.Any(e => e.ID == id);
        }

    }
}