using DrMW.Cqrs.Core.Banks;
using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.PaymentRequests;

public class PayRequest : BaseEntity<Guid>
{
    public int BankId { get; set; }
    public Bank Bank { get; set; }
    
    public decimal Amount { get; set; }
    public Guid OrderId { get; set; }
    
    public string? SuccessLink { get; set; }
    public string? FailLink { get; set; }
    
}