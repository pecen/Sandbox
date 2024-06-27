using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Models
{
    public partial class Recipe
    {
        [JsonProperty("pk")]
        public int Pk { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("featured_image")]
        public Uri FeaturedImage { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cooking_instructions")]
        public object CookingInstructions { get; set; }

        [JsonProperty("ingredients")]
        public List<string> Ingredients { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_updated")]
        public string DateUpdated { get; set; }

        [JsonProperty("long_date_added")]
        public long LongDateAdded { get; set; }

        [JsonProperty("long_date_updated")]
        public long LongDateUpdated { get; set; }
    }
}
