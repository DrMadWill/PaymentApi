using MediatR;

namespace DrMW.Cqrs.Service.Features.Query.GetLink;

public class GetLinkReq : IRequest<string>
{
    public bool Success { get; set; }
    public Guid Token { get; set; }
}