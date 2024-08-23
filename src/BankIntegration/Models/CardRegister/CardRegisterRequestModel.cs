using Newtonsoft.Json;

namespace BankIntegration.Models.CardRegister;

public class CardRegisterRequestModel
{
    /// <summary>
    /// Götürələcək miqdar.
    /// </summary>
    [JsonProperty("amount")]
    public string Amount { get; set; }
    /// <summary>
    /// Success datasinin gödəriləcək url
    /// </summary>
    [JsonProperty("approveURL")]
    public string ResultURL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("cancelURL")]
    public string CancelURL { get; set; }
    /// <summary>
    /// Ödəniş hadisəsinin bitdikdən sonra saytda hara yönləndirələcək onu göstərir
    /// </summary>
    [JsonProperty("declineURL")]
    public string DeclineURL { get; set; }
        
    [JsonProperty("currencyType")]
    public string CurrencyType { get; set; }
        
    [JsonProperty("description")]
    public string Description { get; set; }
    /// <summary>
    /// Always is true
    /// </summary>
    [JsonProperty("directPay")]
    public bool DirectPay { get; set; }
        
    [JsonProperty("language")]
    public string Language { get; set; } 
}