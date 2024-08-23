using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Payriff.Cancel;

public class CreateCancelReq : IRequest<bool>
{
    public Guid? OrderId { get; set; }
    public string Content { get; set; }
}