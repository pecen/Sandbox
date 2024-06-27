using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Models
{
    public partial class Results
    {
        [JsonProperty("pk")]
        public int Pk { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("featured_image")]
        public Uri Featured_Image { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("source_url")]
        public Uri Source_Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cooking_instructions")]
        public CookingInstructions Cooking_Instructions { get; set; }

        [JsonProperty("ingredients")]
        public List<string> Ingredients { get; set; }

        [JsonProperty("date_added")]
        public string Date_Added { get; set; }

        [JsonProperty("date_updated")]
        public string Date_Updated { get; set; }

        [JsonProperty("long_date_added")]
        public long Long_Date_Added { get; set; }

        [JsonProperty("long_date_updated")]
        public long Long_Date_Updated { get; set; }
    }
}
