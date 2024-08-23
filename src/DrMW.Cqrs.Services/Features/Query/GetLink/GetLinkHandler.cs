using DrMW.Cqrs.Core.PaymentRequests;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Query.GetLink;

public class GetLinkHandler : IRequestHandler<GetLinkReq,string>
{
    private readonly IReadRepository<PayRequest, Guid> _linkResultRepository;
    public GetLinkHandler(ISelectRepositories queryRepositories)
    {
        _linkResultRepository = queryRepositories.Repository<PayRequest,Guid>();
    }
    
    public async Task<string> Handle(GetLinkReq request, CancellationToken cancellationToken)
    {
        var link = await _linkResultRepository.GetFirstAsync(s => s.OrderId == request.Token);
        return request.Success ? link?.SuccessLink : link?.FailLink;
    }
}