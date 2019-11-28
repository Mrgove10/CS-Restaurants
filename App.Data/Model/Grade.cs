using System.Text.Json.Serialization;
using App.Data.JsonRepository;

namespace App.Data
{
    public class Grade
    {
        [JsonConverter(typeof(JsonDoubleToDateTime))]
        public double date { get; set; }

        public string grade { get; set; }
        public int score { get; set; }
    }
}