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

            if (query.PageSize.HasValue && query.Page.HasValue) queryBuilder.Append($"&page_size={query.PageSize}&page={query.Page}");
            if (!IsNullOrEmpty(query.Sort)) queryBuilder.Append($"&sort={query.Sort}");

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
        public virtual async Task<GetOrderQueryResponse> GetOrderById(string orderId, string expand = null)
        {
            var queryBuilder = new StringBuilder();

            queryBuilder.Append($"orders/{orderId}");
            queryBuilder.Append(!IsNullOrEmpty(expand)
                ? $"?expand={expand}"
                : $"?expand={CashFlow.IncludeOrderParameters}");

            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", queryBuilder.ToString());
            return await ExecuteRequestAsync<GetOrderQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Mark shipment as delivered. <para> </para>Upon completion the shipment status will be changed to COMPLETED.<para></para>Once all the shipments have been marked as delivered, the entire order's status will also be changed to COMPLETED.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shipmentId">Requested shipment ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShipmentsQueryResponse"/>.</returns>
        public virtual async Task<ShipmentsQueryResponse> CompleteShipmentByShipmentId(string orderId, string shipmentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/shipments/{shipmentId}/complete");
            return await ExecuteRequestAsync<ShipmentsQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Retrieve a specific shipment by its unique ID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="shipmentId">Requested shipment ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShipmentsQueryResponse"/>.</returns>
        public virtual async Task<ShipmentsQueryResponse> GetShipmentById(string orderId, string shipmentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/shipments/{shipmentId}");
            return await ExecuteRequestAsync<ShipmentsQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a list of shipments.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShipmentsQueryResponse"/>.</returns>
        public virtual async Task<ShipmentsQueryResponse> GetShipments(string orderId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/shipments");
            return await ExecuteRequestAsync<ShipmentsQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a specific payment by its unique ID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="paymentId">Requested payment ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/>.</returns>
        public virtual async Task<PaymentQueryResponse> GetPaymentById(string orderId, string paymentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/payments/{paymentId}");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Cancel the order.
        /// </summary>
        /// <param name="orderId">Requested order ID to be cancelled.</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/></returns>
        public virtual async Task<CancelOrderQueryResponse> CancelOrder(string orderId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/cancel");
            return await ExecuteRequestAsync<CancelOrderQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Retrieve a specific payment by its unique ID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/></returns>
        public virtual async Task<PaymentQueryResponse> GetOrderPayments(string orderId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}?expand=payments");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Run the quick processing for an order. <para></para>Only orders with exactly one payment transaction can be quick processed through the API.
        /// </summary>
        /// <param name="orderId">Requested order ID.</param>
        ///  /// <param name="request">Quick process request</param>
        /// <returns>The <see cref="QuickProcessOrderResponse"/></returns>
        public virtual async Task<QuickProcessOrderResponse> QuickProcess(string orderId, QuickProcessRequest request)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/quick-process");
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<QuickProcessOrderResponse>(req, HttpMethod.Post, content);
        }

        /// <summary>
        /// Mark the payment as paid.<para></para>The payment status after marking unpaid is PAID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="paymentId">Individual ID of the payment.</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/>.</returns>
        public virtual async Task<PaymentQueryResponse> MarkPaymentAsPaid(string orderId, string paymentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/payments/{paymentId}/mark-as-paid");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Cancel a payment.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="paymentId">Individual ID of the payment.</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/>.</returns>
        public virtual async Task<PaymentQueryResponse> MarkPaymentAsCancelled(string orderId, string paymentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/payments/{paymentId}/mark-as-cancelled");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Activate the payment (used only with Klarna payments, when the payment transaction status is PENDING_ACTIVATION).<para></para>The payment status after marking unpaid is PAID.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="paymentId">Individual ID of the payment.</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/>.</returns>
        public virtual async Task<PaymentQueryResponse> ActivatePayment(string orderId, string paymentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/payments/{paymentId}/activate");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Mark the payment as unpaid.<para></para>The payment status after marking unpaid is OPEN.
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="paymentId">Individual ID of the payment.</param>
        /// <returns>Response contains the processed item in its new state. <see cref="PaymentQueryResponse"/>.</returns>
        public virtual async Task<PaymentQueryResponse> MarkPaymentAsUnPaid(string orderId, string paymentId)
        {
            var req = PrepareRequest($"{CashFlow.OrderEndPoints}", $"orders/{orderId}/payments/{paymentId}/mark-as-unpaid");
            return await ExecuteRequestAsync<PaymentQueryResponse>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Retrieve a list of shipping-methods.
        /// </summary>
        /// <param name="page">Determines the page that is retrieved (used only in conjunction with page_size).</param>
        /// <param name="pageSize">Determines the number of items included on a page of the retrieved list.</param>
        /// <param name="sort">id-asc : Ascending order by the ID <br/>id-desc : Descending order by the ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShippingMethodsQueryResponse"/>.</returns>
        public virtual async Task<ShippingMethodsQueryResponse> GetShippingMethods(int? pageSize, int? page, string sort = null)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("shipping-methods");
            if (pageSize.HasValue && page.HasValue) queryBuilder.Append($"?page_size={pageSize}&page={page}");
            if (!IsNullOrEmpty(sort)) queryBuilder.Append($"&sort={sort}");

            var req = PrepareRequest(queryBuilder.ToString());
            return await ExecuteRequestAsync<ShippingMethodsQueryResponse>(req, HttpMethod.Get);
        }


        /// <summary>
        /// Retrieve a list of payment-methods.
        /// </summary>
        /// <param name="page">Determines the page that is retrieved (used only in conjunction with page_size).</param>
        /// <param name="pageSize">Determines the number of items included on a page of the retrieved list.</param>
        /// <param name="sort">id-asc : Ascending order by the ID <br/>id-desc : Descending order by the ID</param>
        /// <returns>Response contains the processed item in its new state. <see cref="ShippingMethodsQueryResponse"/>.</returns>
        public virtual async Task<PaymentMethodsQueryResponse> GetPaymentMethods(int? pageSize, int? page, string sort = null)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("payment-methods");
            if (pageSize.HasValue && page.HasValue) queryBuilder.Append($"?page_size={pageSize}&page={page}");
            if (!IsNullOrEmpty(sort)) queryBuilder.Append($"&sort={sort}");

            var req = PrepareRequest(queryBuilder.ToString());
            return await ExecuteRequestAsync<PaymentMethodsQueryResponse>(req, HttpMethod.Get);
        }

    }
}
