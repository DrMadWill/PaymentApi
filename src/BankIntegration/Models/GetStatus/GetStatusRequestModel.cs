using Newtonsoft.Json;

namespace BankIntegration.Models.GetStatus;

public class GetStatusRequestModel
{
    [JsonProperty("languageType")]
    public string Lang { get; set; }
    [JsonProperty("orderId")]
    public string POrderId { get; set; }
    [JsonProperty("sessionId")]
    public string PSessionId { get; set; }     
}