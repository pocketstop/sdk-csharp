# Pocketstop REST API Library for .NET

Pocketstop provides a simple HTTP-based API for interacting with the Pocketstop Social CRM Platform. Learn more at [http://www.pocketstop.com][0]

### Installation

#### Via NuGet

Install REST API wrapper:

    Install-Package Pocketstop

### Sample Usage (Send an SMS)

    using Pocketstop;
    var pocketstop = new PocketstopRestClient("accountId", "apiKey");
    dynamic msg = pocketstop.SendSmsMessage("15551112222", "15553334444", "Can you believe it's this easy to send an SMS?!");
    
### Sample Usage (Generate a QR Code)

    using Pocketstop;
    var pocketstop = new PocketstopRestClient("accountId", "apiKey");
    dynamic qr = pocketstop.GenerateQrCode("Your data here", "150x150");

[0]: http://www.Pocketstop.com