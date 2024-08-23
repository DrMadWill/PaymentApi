namespace DrMW.Cqrs.Models.Requests;

public class EpointPaymentResult
{
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    
    public string Status { get; set; }
    public string Code { get; set; }
    
    public string BankTransaction { get; set; }
    public string RRN { get; set; }
    public string Transaction { get; set; }
    public string CardMask { get; set; }
}