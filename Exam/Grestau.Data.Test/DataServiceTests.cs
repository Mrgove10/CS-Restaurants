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
                [{""ID"":""25bb913e-ce3b-4bba-9265-ea054befb489"",""Name"":""AemxAyNdYW"",""Phone"":""295525"",""Description"":""CTrJHeWphV"",""Email"":""KVTAPaIRro@test123.com"",""Adress"":{""ID"":""1959df8b-8fdf-4ed5-aee5-ae043ba58af1"",""Numero"":686,""Rue"":""bzRsZpWZwi"",""CodePostal"":30332,""Ville"":""sgJooiEbcq""},""Rating"":{""ID"":""2e562584-db45-4407-a604-6b389b4f0847"",""Date"":""2020-01-05T00:41:20.4096155"",""Stars"":6,""Comment"":""VDqMjYiilVIutrtfhCTFfaxywWsFAXYpBpUSjjzsShgrjlQwuDWZJlEuGrQMfdhNxTsDXavyCamyuFOKFwKxByfQlZMrSmNpzStQsNYUHXWiyGAAcGHjSkLyncRyNDgPNxybMySsXpqecxSfYLPMfdWPGvcQwaGDrGVAHYodoPMduhWqKlZBoTkjbjVRWCvwimmVbRYzXlYQRtUYYlFKBFOXWlZYDXHlTQuHvAPtNZeDvUShOwslwludXOzprAw""}},{""ID"":""51b9b050-75a4-472b-adef-139e6c2f0232"",""Name"":""XCfsoXIGLI"",""Phone"":""436254"",""Description"":""Bmtovhwejh"",""Email"":""Q0CPDGcL9c@test123.com"",""Adress"":{""ID"":""16137dcb-3a47-491a-9c67-fcde086d7822"",""Numero"":143,""Rue"":""jBSUOjpSCM"",""CodePostal"":79498,""Ville"":""oVIwPfhdxX""},""Rating"":{""ID"":""05b88a98-6fa8-457d-b9c6-31cc2d4c2574"",""Date"":""2020-01-05T00:41:20.5445631"",""Stars"":9,""Comment"":""LiywnTeBIIpKHFrCOXtDDBXoIQMHmBXUwSYHTGZTSVqizLBrXdTGEUtJLKoWHXPHkUOohkiIyakhLopxPUjJhRQcYPvJRCMvGjyexMKmuLHejLyWVrHmnGZSEmQRpYqvNpbbqKACKwOWJlsNQZoZvZHAKfZLwsxVUMQujWgKrEbrrCITtDBQkQAoibRKkoGSysBxVxdusdiqxPIHWGRtrhlELcMIFVaCxJszBLxwZGXHiKqSTJndXNbRHxlslVo""}},{""ID"":""b868b5fa-fcb7-4bf3-a760-176053205722"",""Name"":""QwUtZTbfkU"",""Phone"":""613798"",""Description"":""AVSLfocsAC"",""Email"":""D6U8TE02Vb@test123.com"",""Adress"":{""ID"":""8fdc6c14-64de-4b0b-b4c1-b84d009a60b9"",""Numero"":30,""Rue"":""uKDcUCurGd"",""CodePostal"":57186,""Ville"":""spFBIGwQDl""},""Rating"":{""ID"":""33da4010-dc54-44c6-aaa3-9f82ddbba881"",""Date"":""2020-01-05T00:41:20.5452698"",""Stars"":0,""Comment"":""KORLZTkkzesFccpqUPbpzTXaJyBIuxtAqRsfZvDIAVsCzkdZTPcBbwErqrBaSbpBksOKjKRZLTodaVaZUcpfVrYuMBoiucqYfqRHWTpJyCqIHaQVRbGpmKfsTTxiVifidPykESCBmggSBQmmlTQSWAmUKYoCVHnQXHercgRyZEDFeNrChLxCRMMdddZfeAgfsQvtluJECRtRwgpxhlUJKlyKvBOzGlUYYXNOSxQnCszATugwnbxsfXVHRkykfKy""}},{""ID"":""1b06374b-7fa8-4b2f-9231-27fa669b4f05"",""Name"":""hDXzPnACVA"",""Phone"":""583925"",""Description"":""yGYlkjtZDI"",""Email"":""NDLqOEOUWY@test123.com"",""Adress"":{""ID"":""a9ead0f7-a3e5-4e3a-9274-fbc77e3dade7"",""Numero"":901,""Rue"":""cMvNXxQCWT"",""CodePostal"":89229,""Ville"":""ScUbsWOexl""},""Rating"":{""ID"":""92349db1-a982-4ef9-a329-f8e663850e56"",""Date"":""2020-01-05T00:41:20.5456442"",""Stars"":7,""Comment"":""aPYBuszOpzjaEvkzjcoARtsbHiXIkOhxcjXBeUYAyAXzjBQgIWeBJkWgWwtMUrdaRlyUXjVODnCRVtsGRqzOjgorNqehaMgHWxhxDwIZBQxVhFKcEnuerPqlwGGhEnnrHvuYLuDVhaMTiTKIfBdnRBPGGwAwpbUNcFNmKmRJkZwQCXCdwyBCKAZGgoSOuGgGGzqdGXytkTCsFyDiuXArZRCcgHGVTCPetpKDgZWYzISrxhAhkjTWFpgoxOwzRca""}},{""ID"":""3ed757da-98ba-476e-95ce-513108421b51"",""Name"":""NPwzceZtoW"",""Phone"":""736123"",""Description"":""BUysEerHyh"",""Email"":""PoCvMThHjP@test123.com"",""Adress"":{""ID"":""02a5d3de-2348-4b75-887a-b49980fd3bbb"",""Numero"":467,""Rue"":""ukhxWdxPpm"",""CodePostal"":69888,""Ville"":""qyKyvGRvjt""},""Rating"":{""ID"":""c97f85be-df7a-4359-80cc-ba27cdde6321"",""Date"":""2020-01-05T00:41:20.546116"",""Stars"":5,""Comment"":""UTjNWEQWeBClXvGtgSjdfOgrneamdcoxEtIefbQehWOpnMmCpNkcAPxGnrardesBMFgenbOEBEwJAqEarYwQsMxovCrnBZACdMdifIPNzfavToFwnAzFhcJzIsikkaDcEtfnNWuiIjRMlBVGwuABZuUBDdanaedYcyrZJSiQFRxyKwOGXcnpZCCJYekjwGIdGsjnJvxeMkvIwWrGPTPxrnzawhAfizUyIUsRNbwbeJdpGuMCmdUdrKmSsJqcvSw""}}]
                ";
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