using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grestau.Data.Model;
using Grestau.Data.Services;
using Microsoft.AspNetCore.Http;

namespace Grestau.Web
{
    public partial class RestaurantsController : Controller
    {
        private readonly RestaurantService _restaurantService = new RestaurantService();
        private readonly AdressService _adressService = new AdressService();
        private readonly RatingService _ratingService = new RatingService();
        private readonly DataService _dataService = new DataService();

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _restaurantService.GetAllRestaurant());
        }

        // GET: Restaurants/Details/5
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

        public async Task<IActionResult> Home()
        {
            return View(await _restaurantService.GetTopFiveRestaurant());
        }

        public async Task<IActionResult> Ratings()
        {
            return View(await _restaurantService.GetTopFiveRestaurant());
        }
    }
}