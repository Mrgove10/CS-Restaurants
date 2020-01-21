using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Grestau.Data.Model;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    [ExcludeFromCodeCoverage]
    public class DataRatingTest
    {
        private DataService _dataService;

        [SetUp]
        public void Setup()
        {
            _dataService = new DataService();
        }


        [Test]
        public void ClearDataBaseTest()
        {
            _dataService.ClearDatabase();
            using var dbContext = new RestaurantContext();
            Assert.IsEmpty(dbContext.Restaurants);
        }

        [Test]
        public void ImportTest()
        {
            _dataService.ClearDatabase();
            var jsonString = @"
[{""ID"":""2c529f1a-3432-4326-9a3c-26eebb21fa47"",""Name"":""Restau 15"",""Phone"":""1515151515"",""Description"":""test"",""Email"":""test@test.com"",""Adress"":{""ID"":""86ed202a-7c73-4910-86e5-ceaa4416cc31"",""Numero"":16,""Rue"":""mayencin 2"",""CodePostal"":151515,""Ville"":""voiron""},""Rating"":{""ID"":""024c02b5-5228-4786-9172-44d83c9a13f6"",""Date"":""2020-01-07T00:00:00"",""Stars"":5,""Comment"":""1515151515""}},{""ID"":""61189d7e-a352-44a7-a090-b391fadf80ac"",""Name"":""1580"",""Phone"":""1580"",""Description"":""1580"",""Email"":""1580@fg.com"",""Adress"":{""ID"":""23b72317-384a-4e44-b6bc-c410a0a11111"",""Numero"":1580,""Rue"":""1580"",""CodePostal"":1580,""Ville"":""1580""},""Rating"":{""ID"":""8d00cfe1-5250-4635-98d6-15b9a25df589"",""Date"":""2020-01-02T00:00:00"",""Stars"":10,""Comment"":""lol""}},{""ID"":""3a4ecaf6-1276-4f1d-97a5-93d7c78f99aa"",""Name"":""18"",""Phone"":""18"",""Description"":""18"",""Email"":""18@dsf.com"",""Adress"":{""ID"":""5130e5d0-004a-4490-bc36-f272a1af94b2"",""Numero"":18,""Rue"":""18"",""CodePostal"":18,""Ville"":""18""},""Rating"":{""ID"":""8641d73a-4421-4a24-8c06-130207fac7f7"",""Date"":""2020-01-02T00:00:00"",""Stars"":2,""Comment"":""sdf""}},{""ID"":""c63da71f-895c-486a-a86e-8fb6fc23f652"",""Name"":""78789789"",""Phone"":""78789789"",""Description"":""78789789"",""Email"":""78789789@f.fr"",""Adress"":{""ID"":""8639d3b7-9523-4c7a-a8be-9d633cd43533"",""Numero"":78789789,""Rue"":""78789789"",""CodePostal"":78789789,""Ville"":""78789789""},""Rating"":{""ID"":""b569a2ea-b5cd-499d-86a1-1e19fdeabf6a"",""Date"":""2020-01-15T00:00:00"",""Stars"":7,""Comment"":""454859""}},{""ID"":""0449c1fb-db3c-4d9f-814f-6bece0a09ee4"",""Name"":""34"",""Phone"":""34"",""Description"":""34"",""Email"":""34@34.co"",""Adress"":{""ID"":""91fb8203-a3df-4f12-8f9b-cd48d926bd68"",""Numero"":34,""Rue"":""34"",""CodePostal"":34,""Ville"":""34""},""Rating"":{""ID"":""57001cb7-6835-454a-bba0-d4d5ef432f88"",""Date"":""2020-01-02T00:00:00"",""Stars"":8,""Comment"":""kkk""}}]                ";
            _dataService.ImportData(jsonString);
            using var dbContext = new RestaurantContext();
            Assert.IsTrue(dbContext.Restaurants.Count() == 5);
        }

        [Test]
        public void ExportTest()
        {
            var v = _dataService.ExportData();
            Assert.IsNotEmpty(v);
        }
    }
}