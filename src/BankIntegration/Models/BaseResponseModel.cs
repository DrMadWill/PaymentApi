using Newtonsoft.Json;

namespace BankIntegration.Models;

public class BaseResponseModel
{
    [JsonProperty("code")]
    public string BankCode { get; set; }
        
    [JsonProperty("internalMessage")]
    public string InternalMessage { get; set; }
       
    [JsonProperty("message")]
    public string Message { get; set; }
}