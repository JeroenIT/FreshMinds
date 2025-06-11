using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace studenthousing.Models
{
    public class Test
    {
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
    }

}
