using Newtonsoft.Json;
using PayriffIntegration.Models;

namespace BankIntegration.Models.GetStatus;
public class GetStatusResponseModel:BaseResponseModel
{
    [JsonProperty("payload")] public GetStatusPayLoad Payload { get; set; }
}

public class GetStatusPayLoad
{
        
    [JsonProperty("orderType")]
    public string OrderType { get; set; }
    [JsonProperty("orderstatus")]
    public string OrderStatus { get; set; }
    [JsonProperty("payDate")]
    public string PayDate { get; set; }
    [JsonProperty("receipt")]
    public string Receipt { get; set; }
    [JsonProperty("refundAmount")]
    public string RefundAmount { get; set; }
    [JsonProperty("refundCurrency")]
    public string RefundCurrency { get; set; }
    [JsonProperty("refundDate")]
    public string BankCode { get; set; }
    [JsonProperty("sessionID")]
    public string SessionId { get; set; }
    [JsonProperty("twoId")]
    public string TwoId { get; set; }
    [JsonProperty("twodate")]
    public string TwoDate { get; set; }


}
