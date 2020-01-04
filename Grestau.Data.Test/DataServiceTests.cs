using Grestau.Data;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    public class DataRatingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExportTest()
        {
           var ds = new DataService();
           ds.ExportData();
        }
    }
}