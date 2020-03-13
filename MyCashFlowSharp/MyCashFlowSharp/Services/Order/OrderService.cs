using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyCashFlowSharp.Entities;
using MyCashFlowSharp.Extensions;
using MyCashFlowSharp.Infrastructure;
using static System.String;

namespace MyCashFlowSharp.Services.Order
{
    public class OrderService : MyCashFlowService
    {
        /// <summary>
        /// Creates a new instance of <see cref="OrderService" />.
        /// </summary>
        /// <param name="storeName">store name</param>
        /// <param name="userName">User name</param>
        /// <param name="apiKey">An API access token for the shop.</param>
        public OrderService(string storeName, string userName, string apiKey) : base(storeName, userName, apiKey)
        {
        }

        /// <summary>
        /// Retrieve a list of the store's orders.
        /// </summary>
        public virtual async Task<OrdersQueryResponse> GetOrders(OrderQueryRequest query)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(!IsNullOrEmpty(query.Expand)
                    ? $"orders?expand={query.Expand}"
                    : $"orders?expand={CashFlow.IncludeOrderParameters}");

            // filter by archivedAtFrom and archivedAtTo
            if (!IsNullOrEmpty(query.ArchivedAtFrom)) queryBuilder.Append($"&archived_at-from={query.ArchivedAtFrom}");
            if (!IsNullOrEmpty(query.ArchivedAtTo)) queryBuilder.Append($"&archived_at-to={query.ArchivedAtTo}");

            // filter by createdFrom and createdTo
            if (!IsNullOrEmpty(query.CreatedFrom)) queryBuilder.Append($"&created_at-from={query.CreatedFrom}");
            if (!IsNullOrEmpty(query.CreatedTo)) queryBuilder.Append($"&created_at-to={query.CreatedTo}");

            // filter by updatedFrom and updatedTo
            if (!IsNullOrEmpty(query.UpdatedAtFrom)) queryBuilder.Append($"&updated_at-from={query.UpdatedAtFrom}");
            if (!IsNullOrEmpty(query.UpdatedAtTo)) queryBuilder.Append($"&updated_at-to={query.UpdatedAtTo}");

            // filter by shipmentsCompletedFrom and shipmentsCompletedTo
            if (!IsNullOrEmpty(query.ShipmentsCompletedFrom)) queryBuilder.Append($"&shipments_completed_at-from={query.ShipmentsCompletedFrom}");
            if (!IsNullOrEmpty(query.ShipmentsCompletedTo)) queryBuilder.Append($"&shipments_completed_at-to={query.ShipmentsCompletedTo}");

            // filter by order status
            if (!IsNullOrEmpty(query.Status)) queryBuilder.Append($"&status={query.Status}");

            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", queryBuilder.ToString());
            return await ExecuteRequestAsync<OrdersQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a specific order by its unique ID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="expand">Comma-separated list of expandable sub-resources. <para></para>possible values could be: <br/>payments<br/>products<br/>products.return_reasons<br/>shipments<br/>tax_summary<br/>comments<br/>events</param>
        /// <returns>The <see cref="Order"/> request order</returns>
        public virtual async Task<OrdersQueryResponse> GetOrderById(string orderId, string expand)
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.Append($"orders/{orderId}");
            queryBuilder.Append(!IsNullOrEmpty(expand)
                ? $"?expand={expand}"
                : $"?expand={CashFlow.IncludeOrderParameters}");

            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", queryBuilder.ToString());
            return await ExecuteRequestAsync<OrdersQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Mark shipment as delivered. <para> </para>Upon completion the shipment status will be changed to COMPLETED.<para></para>Once all the shipments have been marked as delivered, the entire order's status will also be changed to COMPLETED.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shipmentId">Requested shipment ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShipmentsQueryResponse"/>.</returns>
        public virtual async Task<ShipmentsQueryResponse> CompleteShipment(string orderId, string shipmentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"/orders/{orderId}/shipments/{shipmentId}/complete");
            return await ExecuteRequestAsync<ShipmentsQueryResponse>(req, HttpMethod.Post);
        }
    }
}
