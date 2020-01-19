using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        /// <summary>
        /// Get data page
        /// </summary>
        /// <returns></returns>
        public IActionResult Data()
        {
            return View();
        }


        /// <summary>
        /// post of the data page
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Data(IFormCollection form)
        {
            string dataraw = form["dataraw"];
            _dataService.ImportData(dataraw);
            return RedirectToAction("Index");
        }
    }
}