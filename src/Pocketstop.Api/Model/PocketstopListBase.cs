using System;
using System.Collections.Generic;

namespace Pocketstop
{
	/// <summary>
	/// Base class for list resource data
	/// </summary>
	public class PocketstopListBase : PocketstopBase
	{
		/// <summary>
		/// The current page number. First page is 1.
		/// </summary>
		public int Page { get; set; }
		/// <summary>
		/// The total number of pages.
		/// </summary>
		public int PageCount { get; set; }
		/// <summary>
		/// How many items are in each page
		/// </summary>
		public int PageSize { get; set; }
		/// <summary>
		/// The total number of items in the list.
		/// </summary>
		public int RecordCount { get; set; }
		/// <summary>
		/// The URI for the first page of this list.
		/// </summary>
		public Uri FirstPageUri { get; set; }
		/// <summary>
		/// The URI for the next page of this list.
		/// </summary>
		public Uri NextPageUri { get; set; }
		/// <summary>
		/// The URI for the previous page of this list.
		/// </summary>
		public Uri PreviousPageUri { get; set; }
		/// <summary>
		/// The URI for the last page of this list.
		/// </summary>
		public Uri LastPageUri { get; set; }
	}
}