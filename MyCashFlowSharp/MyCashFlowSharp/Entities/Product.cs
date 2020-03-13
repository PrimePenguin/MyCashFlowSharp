using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCashFlowSharp.Entities
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

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
        public int PurchasePrice { get; set; }

        [JsonProperty("vat_rate")]
        public int VatRate { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("warranty")]
        public int Warranty { get; set; }

        [JsonProperty("brand_id")]
        public int BrandId { get; set; }

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

        [JsonProperty("stock_item")]
        public StockItem StockItem { get; set; }

        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }
}
