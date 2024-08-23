using DrMadWill.EventBus.Base.Events;

namespace DrMW.Cqrs.Service.Events.Integrations.Models;

public class AcceptedPaymentIntegrationEvent : IntegrationEvent
{
    public Guid OrderId { get; set; }
    public decimal Aumount { get; set; }
    public bool Succeed { get; set; }
}