using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Paymentrs;

public class PaymentDetail :  BaseEntity<Guid>
{
    /// <summary>
    /// Form Bank Send
    /// </summary>
    public string? BankSession { get; set; }
    /// <summary>
    /// From Bank Send
    /// </summary>
    public string? BankOrder { get; set; }
    
    /// <summary>
    /// Payment Transaction 
    /// </summary>
    public string? Transaction { get; set; }
    public string? CardMask { get; set; }
    public string? CardHolderName { get; set; }
    public string? BankTransaction { get; set; }
    public string? BankOperationCode { get; set; }
    public string? BankRnn { get; set; }

    public Payment? Payment { get; set; }
    
}