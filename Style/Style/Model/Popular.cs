using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Style.Model
{
    class Popular
    {
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("time")]
        public string time { get; set; }

        [JsonProperty("Review")]
        public string Review { get; set; }

        public string username { get; set; }

    }
}
