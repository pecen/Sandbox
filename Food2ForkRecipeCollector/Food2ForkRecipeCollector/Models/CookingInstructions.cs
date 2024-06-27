using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector.Models
{
    public partial class CookingInstructions
    {
        [JsonProperty("ValueKind")]
        public long ValueKind { get; set; }
    }
}
