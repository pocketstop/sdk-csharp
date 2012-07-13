using RestSharp;
using RestSharp.Validation;

namespace Pocketstop
{
	public partial class PocketstopRestClient
	{
		/// <summary>
		/// Send a new SMS message to the specified recipients.
		/// Makes a POST request to the SMSMessages List resource.
		/// </summary>
		/// <param name="from">The phone number to send the message from. Must be a Pocketstop-provided short code or authorized local (not toll-free) number.</param>
		/// <param name="to">The phone number to send the message to.</param>
		/// <param name="body">The message to send. Must be 160 characters or less.</param>
		public dynamic SendSmsMessage(string from, string to, string body)
		{
			return SendSmsMessage(from, to, body, string.Empty);
		}

		/// <summary>
		/// Send a new SMS message to the specified recipients
		/// Makes a POST request to the SMSMessages List resource.
		/// </summary>
		/// <param name="from">The phone number to send the message from. Must be a Pocketstop-provided short code or  or authorized local (not toll-free) number.</param>
		/// <param name="to">The phone number to send the message to.</param>
		/// <param name="body">The message to send. Must be 160 characters or less.</param>
		/// <param name="statusCallback">A URL that Pocketstop will POST to when your message is processed. Pocketstop will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
		private dynamic SendSmsMessage(string from, string to, string body, string statusCallback)
		{
			Validate.IsValidLength(body, 160);
			Require.Argument("from", from);
			Require.Argument("to", to);
			Require.Argument("body", body);

			var request = new RestRequest(Method.POST)
			              	{
			              		Resource = "SMS/Messages"
			              	};
			//if (statusCallback.HasValue())
			//{
			//    sms.StatusCallback = statusCallback;
			//}
			//request.AddBody(request.JsonSerializer.Serialize(sms));
			request.AddParameter("From", from);
			request.AddParameter("To", to);
			request.AddParameter("Body", body);

			return Execute<dynamic>(request);
		}
	}
}