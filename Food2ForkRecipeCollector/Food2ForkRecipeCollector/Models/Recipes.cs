using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Models
{
    public partial class Recipes
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public Uri Previous { get; set; }

        [JsonProperty("results")]
        public List<Results> Results { get; set; }
    }
}
