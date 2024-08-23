using BankIntegration.Models;
using Newtonsoft.Json;

namespace PayriffIntegration.Models.CardRegister;

public class CardResponseModel :BaseResponseModel
{
    [JsonProperty("payload")]
    public PayLoad Payload { get; set; } 
}