using Newtonsoft.Json;

namespace BankIntegration.Models.Create;

public class CreateRequestModel
{
    [JsonProperty("amount")]
    public decimal Amount { get; set; }
        
    [JsonProperty("approveURL")]
    public string ResultURL { get; set; }
        
    [JsonProperty("cancelURL")]
    public string CancelURL { get; set; }
        
    [JsonProperty("cardUuid")]
    public string CardUuid { get; set; }
        
    [JsonProperty("currencyType")]
    public string Currency { get; set; }
        
    [JsonProperty("declineURL")]
    public string DeclineURL { get; set; }
        
    [JsonProperty("description")]
    public string Description { get; set; }
        
    [JsonProperty("directPay")]
    public bool DirectPay { get; set; }
        
    [JsonProperty("installmentPeriod")]
    public int InstallmentPeriod { get; set; }
        
    [JsonProperty("installmentProductType")]
    public string InstallmentProductType { get; set; }
        
    [JsonProperty("language")]
    public string Language { get; set; }
        
    [JsonProperty("senderCardUID")]
    public string SenderCardUID { get; set; }

}