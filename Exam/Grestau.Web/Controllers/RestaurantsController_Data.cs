using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grestau.Web
{
    public partial class RestaurantsController
    {
        public IActionResult Data()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Data(IFormFile file)
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
    }
}