using AutoMapper;
using DrMW.Cqrs.Core.PaymentRequests;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Service.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Concretes.Edu;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IReadRepository<PayRequest, Guid> _readRepository;
    private readonly IWriteRepository<PayRequest, Guid> _writeRepository;
    public PaymentService(ISelectRepositories selectRepositories,IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _readRepository = selectRepositories.Repository<PayRequest, Guid>();
        _writeRepository = _unitOfWork.Repository<PayRequest, Guid>();
    }
    
    public async Task<List<PayRequest>> GetAll()
    {
        return (await _readRepository.GetAllListAsync())
            .Select(_mapper.Map<PayRequest>)
            .ToList(); 
    }

    public async Task<PayRequest> Get(Guid id)
    {
        var group = await _readRepository.GetFirstAsync(s => s.Id == id);
        return _mapper.Map<PayRequest>(group); 
    }

    public async Task<bool> AddAsync(PayRequest req)
    {
        await _writeRepository.AddAsync((req));
        await _unitOfWork.CommitAsync();
        return true;
    }


}