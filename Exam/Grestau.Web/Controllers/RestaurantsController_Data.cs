using System;
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
        /// Returns data to the user
        /// </summary>
        /// <returns></returns>
        public ActionResult saveData()
        {
            var data = _dataService.ExportData();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = "GrestauExport_" + DateTime.Now + ".json";
            return output;
        }

        /// <summary>
        /// post of the data page
        /// </summary>
        /// <param name="form"></param>
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