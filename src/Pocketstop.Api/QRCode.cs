using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace Pocketstop
{
	public partial class PocketstopRestClient
	{
		/// <summary>
		/// Generate a QR Code
		/// Makes a POST request to the QR resource.
		/// </summary>
		/// <param name="data">The data to encode in the QR Code.</param>
		/// <param name="size">height x width dimensions (default to 150x150 up to max 500x500).</param>
		public dynamic GenerateQrCode(string data, string size = "150x150")
		{
			Require.Argument("data", data);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "QR"
			};
			dynamic payload = new ExpandoObject();
			payload.data = data;
			payload.size = size;
			request.AddBody(payload);

			return Execute<dynamic>(request);
		}
	}
}