using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Translation
    {
        [JsonProperty("language")] 
        public string Language { get; set; }

        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("Description")] 
        public string Description { get; set; }

        [JsonProperty("information")] 
        public string Information { get; set; }

        [JsonProperty("seo_title")] 
        public string SeoTitle { get; set; }

        [JsonProperty("seo_page_title")] 
        public string SeoPageTitle { get; set; }

        [JsonProperty("seo_meta_description")] 
        public string SeoMetaDescription { get; set; }
    }

    public class ProductsQueryResponse
    {
        [JsonProperty("data ")]
        public List<Product> Products { get; set; }

        [JsonProperty("meta")]
        public MetaData MetaData { get; set; }
    }
}
