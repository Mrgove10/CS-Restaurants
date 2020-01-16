using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grestau.Data.Model;
using Grestau.Data.Services;
using Microsoft.AspNetCore.Http;

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

        // GET: Restaurants/Data
        public async Task<IActionResult> Home()
        {
            return View(await _restaurantService.GetTopFiveRestaurant());
        }

        // GET: Restaurants/Data
        public async Task<IActionResult> Ratings()
        {
            return View(await _restaurantService.GetTopFiveRestaurant());
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

        [HttpPost]
        public async Task<IActionResult> Data(IFormFile file)
        {
            var filePaths = new List<string>();


            // full path to file in temp location
            var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
            filePaths.Add(filePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                _dataService.ImportData(stream.ToString());
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok();
//            return Ok(new {count = files.Count, size, filePaths});
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
                //restaurant.ID = Guid.NewGuid();
                _restaurantService.AddRestaurant(restaurant);

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

        // GET: Restaurants/Rating/5
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