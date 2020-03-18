using System;
using System.Collections.Generic;
using MyCashFlowSharp.Helpers;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("supplier_code")]
        public string SupplierCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("information")]
        public string Information { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("purchase_price")]
        public string PurchasePrice { get; set; }

        [JsonProperty("vat_rate")]
        public string VatRate { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("warranty")]
        public string Warranty { get; set; }

        [JsonProperty("brand_id")]
        public string BrandId { get; set; }

        [JsonProperty("supplier_id")]
        public int SupplierId { get; set; }

        [JsonProperty("available_from")]
        public string AvailableFrom { get; set; }

        [JsonProperty("available_to")]
        public string AvailableTo { get; set; }

        [JsonProperty("order_limit")]
        public string OrderLimit { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("visible_from")]
        public string VisibleFrom { get; set; }

        [JsonProperty("purchasable_from")]
        public string PurchasableFrom { get; set; }

        [JsonProperty("seo_title")]
        public string SeoTitle { get; set; }

        [JsonProperty("seo_page_title")]
        public string SeoPageTitle { get; set; }

        [JsonProperty("seo_meta_description")]
        public string SeoMetaDescription { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonConverter(typeof(CustomAttributeArrayValueConverter))]
        [JsonProperty("stock_item", NullValueHandling = NullValueHandling.Ignore)]
        public StockItem StockItem { get; set; }

        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }

        [JsonProperty("variations")]
        public List<Variation> Variations { get; set; }

        [JsonProperty("image_links")]
        public List<ImageLink> ImageLinks { get; set; }

        [JsonProperty("visibilities")]
        public List<Visibility> Visibilities { get; set; }
    }

    public class ImageLink
    {
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }
    }

    public class Visibility
    {
        [JsonProperty("version_id")]
        public string VersionId { get; set; }

        [JsonProperty("is_visible")]
        public bool IsVisible { get; set; }
    }
}
