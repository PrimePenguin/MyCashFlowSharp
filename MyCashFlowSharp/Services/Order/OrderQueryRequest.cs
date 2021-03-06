﻿namespace MyCashFlowSharp.Services.Order
{
    public class OrderQueryRequest
    {
        /// <summary>
        /// Comma-separated list of expandable sub-resources. <para></para>possible values could be: <br/>payments<br/>products<br/>products.return_reasons<br/>shipments<br/>tax_summary<br/>comments<br/>events
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// Retrieve orders that have been created on or after the specified date and time.
        /// </summary>
        public string CreatedFrom { get; set; }

        /// <summary>
        /// Retrieve orders that have been created on or before the specified date and time.
        /// </summary>
        public string CreatedTo { get; set; }

        /// <summary>
        /// Retrieve orders whose shipments have been marked as delivered on or after the specified date and time.
        /// </summary>
        public string ShipmentsCompletedFrom { get; set; }

        /// <summary>
        /// Retrieve orders whose shipments have been marked as delivered on or before the specified date and time.
        /// </summary>
        public string ShipmentsCompletedTo { get; set; }

        /// <summary>
        /// Filter orders by their processing status. Possible values are: open, completed, cancelled
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Retrieve orders that have been updated after the specified date and time.
        /// </summary>
        public string UpdatedAtFrom { get; set; }

        /// <summary>
        /// Retrieve orders that have been updated before the specified date and time.
        /// </summary>
        public string UpdatedAtTo { get; set; }

        /// <summary>
        /// Retrieve orders that have been archived on or after the specified date and time.
        /// </summary>
        public string ArchivedAtFrom { get; set; }

        /// <summary>
        /// Retrieve orders that have been archived on or before the specified date and time.
        /// </summary>
        public string ArchivedAtTo { get; set; }

        /// <summary>
        /// Determines the number of items included on a page of the retrieved list.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Determines the page that is retrieved (used only in conjunction with page_size).
        /// </summary>
        public int?  Page { get; set; }

        /// <summary>
        /// id-asc : Ascending order by the order ID<br/>id-desc : Descending order by the order ID<br/>updated_at-asc : Ascending order by the date of most recent update.<br/>updated_at-desc : Descending order by the date of most recent update.<br/>
        /// </summary>
        public string Sort { get; set; }
    }
}