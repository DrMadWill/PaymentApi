using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Core.Others;

namespace DrMW.Cqrs.Core.Paymentrs;

public class Payment : BaseEntity<Guid>
{
    
    public Payment(Guid orderId, decimal amount, int currencyId,  string? not, int statusId ,PaymentDetail? paymentDetail)
    {
        OrderId = orderId;
        Amount = amount;
        CurrencyId = currencyId;
        Not = not;
        StatusId = statusId;
        PaymentDetail = paymentDetail;
    }

    public decimal Amount { get; set; }
    public string? Not { get; set; }
    public string? Reason { get; set; }

    public Guid OrderId { get; set; }

    public PaymentDetail? PaymentDetail { get; set; }
    
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    
}