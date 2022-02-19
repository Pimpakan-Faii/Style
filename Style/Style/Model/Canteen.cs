using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Style.Model
{
   

    public partial class Canteen
    {
        [JsonProperty("Comment")]
        public List<Comment> Comment { get; set; }

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

    public partial class Comment
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Store_Id")]
        public string StoreId { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }
    }
}
