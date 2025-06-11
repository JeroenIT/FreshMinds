using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace studenthousing.Models
{
    public class Activity
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Locatie is verplicht")]
        [JsonPropertyName("place")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Aantal is verplicht")]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Datum is verplicht"),
         DataType(DataType.Date, ErrorMessage = "Voer een geldige datum in")]
        [JsonPropertyName("date")]
        public string Date { get; set; }
        
    }
}