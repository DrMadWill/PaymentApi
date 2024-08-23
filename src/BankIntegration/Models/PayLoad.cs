using Newtonsoft.Json;

namespace BankIntegration.Models;

public class PayLoad
{
    [JsonProperty("orderId")]
    public string OrderId { get; set; }
    [JsonProperty("paymentUrl")]
    public string PaymentUrl { get; set; }
    [JsonProperty("sessionId")]
    public string SessionId { get; set; }
    [JsonProperty("transactionId")]
    public string Transaction { get; set; }
}