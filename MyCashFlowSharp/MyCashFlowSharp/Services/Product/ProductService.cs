using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyCashFlowSharp.Entities;
using MyCashFlowSharp.Extensions;
using MyCashFlowSharp.Infrastructure;
using static System.String;

namespace MyCashFlowSharp.Services.Product
{
    public class ProductService : MyCashFlowService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProductService" />.
        /// </summary>
        /// <param name="storeName">store name</param>
        /// <param name="userName">User name</param>
        /// <param name="apiKey">An API access token for the shop.</param>
        public ProductService(string storeName, string userName, string apiKey) : base(storeName, userName, apiKey)
        {
        }

        /// <summary>
        /// Retrieve a list of products. When fetching products, the default response will be in the default language of the store
        /// </summary>
        /// <param name="page">Determines the page that is retrieved (used only in conjunction with page_size).</param>
        /// <param name="expand">Comma-separated list of expandable sub-resources<para></para>possible values could be<br/>translations<br/>visibilities<br/>category_links<br/>image_links<br/>variations<br/>brand<br/>variations.stock_item</param>
        /// <param name="pageSize">Determines the number of items included on a page of the retrieved list.</param>
        /// <param name="sortByDescending">Descending order by the ID</param>
        public virtual async Task<ProductsQueryResponse> GetProducts(string expand = null, int? pageSize = null, 
            int? page = null, bool? sortByDescending = null)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(!IsNullOrEmpty(expand)
                ? $"products?expand={expand}"
                : $"products?expand={CashFlow.IncludeProductParameters}");

            if (sortByDescending.HasValue && sortByDescending == true) queryBuilder.Append("&sort=id-desc");
            if (pageSize.HasValue && page.HasValue) queryBuilder.Append($"&page_size={pageSize}&page={page}");

            var req = PrepareRequest(queryBuilder.ToString());
            return await ExecuteRequestAsync<ProductsQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a specific product by its unique ID.
        /// </summary>
        /// <param name="productIds"> Required : A comma-separated list of product ids.</param>
        /// <param name="expand">Comma-separated list of expandable sub-resources<para></para>possible values could be<br/>translations<br/>visibilities<br/>category_links<br/>image_links<br/>variations<br/>brand<br/>variations.stock_item</param>
        /// <param name="sortByDescending">Descending order by the ID</param>
        /// <returns>The <see cref="ProductsQueryResponse"/>.</returns>
        public virtual async Task<ProductsQueryResponse> GetProductsById(string productIds, string expand = null, bool? sortByDescending = null)
        {
            var queryBuilder = new StringBuilder();
            if (IsNullOrEmpty(productIds) && IsNullOrEmpty(expand))
            {
                return await GetProducts(CashFlow.IncludeProductParameters);
            }

            queryBuilder.Append($"products?id={productIds}");
            if (sortByDescending.HasValue && sortByDescending == true) queryBuilder.Append("&sort=id-desc");
            queryBuilder.Append(!IsNullOrEmpty(expand)
                ? $"&expand={expand}"
                : $"&expand={CashFlow.IncludeProductParameters}");

            var req = PrepareRequest(queryBuilder.ToString());
            return await ExecuteRequestAsync<ProductsQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Modify a stock item specified by the unique product code of a product or variation.<para></para> Stock items are identified in request by the unique product code of the product or variation they belong to.
        /// </summary>
        /// <param name="productCode">The unique product code of the product or variation the stock item is attached to.</param>
        /// <param name="request">update variant stock request</param>
        public virtual async Task UpdateProductVariantStock(string productCode, UpdateVariantStockRequest request)
        {
            var req = PrepareRequest($"stock/{productCode}");
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// Retrieve a list of suppliers.
        /// </summary>
        /// <param name="page">Determines the page that is retrieved (used only in conjunction with page_size).</param>
        /// <param name="pageSize">Determines the number of items included on a page of the retrieved list.</param>
        /// <param name="sortByDescending">Descending order by the ID</param>
        public virtual async Task<SuppliersQueryResponse> GetSuppliers(int? pageSize = null, int? page = null, bool? sortByDescending = null)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("suppliers");
            if (pageSize.HasValue && page.HasValue) queryBuilder.Append($"?page_size={pageSize}&page={page}");
            if (sortByDescending.HasValue && sortByDescending == true) queryBuilder.Append("&sort=id-desc");

            var req = PrepareRequest(queryBuilder.ToString());
            return await ExecuteRequestAsync<SuppliersQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a stock item specified by the unique product code of a product or variation.
        /// </summary>
        /// <param name="productCode">The unique product code of the product or variation the stock item is attached to.</param>
        public virtual async Task<StocksQueryResponse> GetStockByProductCode(string productCode)
        {
            var req = PrepareRequest($"stock/{productCode}");
            return await ExecuteRequestAsync<StocksQueryResponse>(req, HttpMethod.Get);
        }
    }
}
