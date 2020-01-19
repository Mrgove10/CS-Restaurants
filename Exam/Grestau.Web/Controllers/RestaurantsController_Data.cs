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

        public ActionResult saveData()
        {
            Console.WriteLine("savingg");
            var data = _dataService.ExportData();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = "GrestauExport.json";

            return output;
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