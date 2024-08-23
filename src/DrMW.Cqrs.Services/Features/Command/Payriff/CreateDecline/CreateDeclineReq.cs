using MediatR;

namespace Application.Features.Commands.Payriff.Create.CreateDecline;

public class CreateDeclineReq : IRequest<bool>
{
    public Guid? OrderId { get; set; }
    public string Content { get; set; }
}