using System.Reflection;
using RestSharp;

namespace Pocketstop
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public partial class PocketstopRestClient
	{
		/// <summary>
		/// Pocketstop API version to use when making requests
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// Base URL of API (defaults to https://www.pocketstop.com/api/)
		/// </summary>
		public string BaseUrl { get; set; }
		private string AccountId { get; set; }
		private string ApiKey { get; set; }

		private RestClient _client;

		/// <summary>
		/// Initializes a new client with the specified credentials.
		/// </summary>
		/// <param name="accountId">The AccountId to authenticate with</param>
		/// <param name="apiKey">The ApiKey to authenticate with</param>
		public PocketstopRestClient(string accountId, string apiKey)
		{
			ApiVersion = "v1";
			BaseUrl = "https://www.pocketstop.com/api/";
			AccountId = accountId;
			ApiKey = apiKey;

			// silverlight friendly way to get current version
			var assembly = Assembly.GetExecutingAssembly();
			var assemblyName = new AssemblyName(assembly.FullName);
			var version = assemblyName.Version;

			_client = new RestClient();
			_client.UserAgent = "pocketstop-sdk-csharp/" + version;
			_client.Authenticator = new HttpBasicAuthenticator(AccountId, ApiKey);
			_client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);
		}

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public T Execute<T>(RestRequest request) where T : new()
		{
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					request.RootElement = "";
				}
			};

			request.DateFormat = "s";

			var response = _client.Execute<T>(request);
			return response.Data;
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public RestResponse Execute(RestRequest request)
		{
			return _client.Execute(request);
		}
#endif

		private string GetParameterNameWithEquality(ComparisonType? comparisonType, string parameterName)
		{
			if (comparisonType.HasValue)
			{
				switch (comparisonType)
				{
					case ComparisonType.GreaterThanOrEqualTo:
						parameterName += ">";
						break;
					case ComparisonType.LessThanOrEqualTo:
						parameterName += "<";
						break;
				}
			}
			return parameterName;
		}
	}
}