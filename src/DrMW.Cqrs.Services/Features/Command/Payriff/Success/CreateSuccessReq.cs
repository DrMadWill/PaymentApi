using Application.Features.Commands.Payriff.Create;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Payriff.Success;

public class CreateSuccessReq : BaseCreateRequest,  IRequest<bool>
{
    public Guid? OrderId { get; set; }
   
}
