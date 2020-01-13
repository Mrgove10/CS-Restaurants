using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grestau.Data.Model;
using Grestau.Data.Services;

namespace Grestau.Web
{
    public class RestaurantsController : Controller
    {
        // private readonly RestaurantContext _context;

        /*public RestaurantsController(RestaurantContext context)
        {
            _context = context; 
        }*/

        private readonly RestaurantService _restaurantService = new RestaurantService();
        private readonly AdressService _adressService = new AdressService();
        private readonly RatingService _ratingService = new RatingService();

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

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Restaurants/Data
        public IActionResult Data()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Phone,Description,Email")] Restaurant restaurant,
            [Bind("Numero,Rue,CodePostal,Ville")] Adress adress
        )
        {
            if (ModelState.IsValid)
            {
                restaurant.ID = Guid.NewGuid();
                _restaurantService.AddRestaurant(restaurant);

                adress.ID = Guid.NewGuid();
                _adressService.AddAdress(restaurant, adress);

                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

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
        public async Task<IActionResult> Edit(Guid id,
            [Bind("ID,Name,Phone,Description,Email")]
            Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _restaurantService.UpdateRestaurant(restaurant);
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

        // GET: Restaurants/Delete/5
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

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //   var restaurant = await _context.Restaurants.FindAsync(id);
            var restaurantList = await _restaurantService.GetAllRestaurant(); //.FirstOrDefaultAsync(m => m.ID == id);
            var restaurant = restaurantList.Find(m => m.ID == id);

            _restaurantService.DeleteRestaurant(restaurant);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(Guid id)
        {
            return _restaurantService.GetAllRestaurant().Result.Any(e => e.ID == id);
        }


        // GET: Restaurants/Rating/5
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
    }
}