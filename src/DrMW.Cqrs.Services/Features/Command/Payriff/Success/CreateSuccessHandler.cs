using BankIntegration.Interfaces;
using BankIntegration.Models.GetStatus;
using DrMadWill.EventBus.Base.Abstractions;
using DrMW.Cqrs.Core.Logs;
using DrMW.Cqrs.Core.Others;
using DrMW.Cqrs.Core.Paymentrs;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Repository.Helpers;
using DrMW.Cqrs.Service.Events.Integrations.Models;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Payriff.Success;

public class CreateSuccessHandler : IRequestHandler<CreateSuccessReq,bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWriteRepository<Payment, Guid> _paymentRepository;
    private readonly IPayriffService _payriffService;
    private readonly IEventBus _eventBus;
    public CreateSuccessHandler(IUnitOfWork unitOfWork, IPayriffService payriffService, IEventBus eventBus)
    {
        _unitOfWork = unitOfWork;
        _payriffService = payriffService;
        _eventBus = eventBus;
        _paymentRepository = unitOfWork.Repository<Payment, Guid>();
    }
    
    public async Task<bool> Handle(CreateSuccessReq request, CancellationToken cancellationToken)
    {
        var payload = request.Payload;
        var statusReq = await _payriffService.GetStatus(new GetStatusRequestModel 
            { Lang = "AZ", POrderId = payload.OrderId, PSessionId = payload.SessionId });
        if (statusReq.Payload.OrderStatus !=payload.OrderStatus)
            return false;


        await _unitOfWork.Repository<PaymentRequestLog, Guid>().AddAsync(new PaymentRequestLog
            { Key = $"Payriff | OrderToken : {request.OrderId}", Value = request.JsonString() });
        // add payment
        var payment = new Payment(
            orderId: (Guid)request.OrderId,
            amount: (decimal)payload.PurchaseAmountScr,
            currencyId: Currency.AZN.Id,
            not: payload.JsonString(),
            statusId: Status.Succeed.Id,
            paymentDetail: new PaymentDetail
            {
                BankRnn = payload.Rrn,
                Transaction = payload.InvoiceUuid,
                BankOperationCode = payload.ResponseCode,
                BankTransaction = $"orderId : {payload.OrderId} | sessionId : {payload.SessionId}",
                CardMask = payload?.Pan,
                CardHolderName = payload.Brand
            });
        await _paymentRepository.AddAsync(payment);
               
        // payment accepted
        await _unitOfWork.CommitAsync();
        
        _eventBus.Publish(new AcceptedPaymentIntegrationEvent
        {
            OrderId = request.OrderId.Value,
            Aumount =  (decimal)payload.PurchaseAmountScr,
            Succeed = true
        });

        return true;
    }
}