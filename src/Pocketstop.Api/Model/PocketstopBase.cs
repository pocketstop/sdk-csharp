using System;

namespace Pocketstop
{
	/// <summary>
	/// Base class for all Twilio resource types
	/// </summary>
	public abstract class PocketstopBase
	{
		/// <summary>
		/// Exception encountered during API request
		/// </summary>
		public RestException RestException { get; set; }
		/// <summary>
		/// The URI for this resource, relative to https://api.pocketstop.com
		/// </summary>
		public string Uri { get; set; }
	}
}