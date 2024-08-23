using DrMW.Cqrs.Core.PaymentRequests;

namespace DrMW.Cqrs.Service.Abstractions;

public interface IPaymentService
{
    Task<List<PayRequest>> GetAll();
    Task<PayRequest> Get(Guid id);
    Task<bool> AddAsync(PayRequest req);
}