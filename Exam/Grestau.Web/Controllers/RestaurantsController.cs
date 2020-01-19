using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grestau.Data.Services;

namespace Grestau.Web
{
    public partial class RestaurantsController : Controller
    {
        private readonly RestaurantService _restaurantService = new RestaurantService();
        private readonly AdressService _adressService = new AdressService();
        private readonly RatingService _ratingService = new RatingService();
        private readonly DataService _dataService = new DataService();

        /// <summary>
        /// Get details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
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
        /// Get index 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _restaurantService.GetAllRestaurant());
        }

        /// <summary>
        /// Get Home Page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Home()
        {
            return View(await _restaurantService.GetTopFiveRestaurant());
        }

        /// <summary>
        /// Get ratings page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Ratings()
        {
            return View(await _restaurantService.GetAllRestaurant());
        }
    }
}