using Newtonsoft.Json;

namespace BankIntegration.Models;

public class BaseRequestModel
{
    [JsonProperty("merchant")]
    public string Merchant { get; set; }

    [JsonProperty("body")]
    public object Body { get; set; }
}
