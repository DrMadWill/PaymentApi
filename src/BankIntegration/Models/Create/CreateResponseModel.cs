using Newtonsoft.Json;
using PayriffIntegration.Models;

namespace BankIntegration.Models.Create;

public class CreateResponseModel  : BaseResponseModel
{
    [JsonProperty("payload")]
    public PayLoad Payload { get; set; } 
}