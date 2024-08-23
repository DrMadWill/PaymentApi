using Application.Features.Commands.Payriff.Create.CreateDecline;
using DrMadWill.EventBus.Base.Abstractions;
using DrMW.Cqrs.Core.Logs;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Service.Events.Integrations.Models;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Payriff.CreateDecline;

public class CreateDeclineHandler : IRequestHandler<CreateDeclineReq,bool>
{
    private readonly IEventBus _eventBus;
    private readonly IUnitOfWork _unitOfWork;
    public CreateDeclineHandler(IEventBus eventBus,IUnitOfWork unitOfWork)
    {
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<bool> Handle(CreateDeclineReq request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Repository<PaymentRequestLog, Guid>().AddAsync(new PaymentRequestLog
            { Key = $"Payriff | OrderToken : {request.OrderId}", Value = request.Content });
        await _unitOfWork.CommitAsync();
        _eventBus.Publish(new AcceptedPaymentIntegrationEvent
        {
            OrderId = request.OrderId.Value,
            Succeed = false
        });
        return true;
    }
}