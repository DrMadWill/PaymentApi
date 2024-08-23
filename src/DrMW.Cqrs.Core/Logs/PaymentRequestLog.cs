using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Logs;

public class PaymentRequestLog : BaseEntity<Guid>
{
    public string Key { get; set; }
    public string Value { get; set; }
}