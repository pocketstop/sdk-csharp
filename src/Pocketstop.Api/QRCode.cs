using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace Pocketstop
{
	public partial class PocketstopRestClient
	{
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