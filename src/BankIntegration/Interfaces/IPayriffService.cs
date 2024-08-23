using BankIntegration.Models.Create;
using BankIntegration.Models.GetStatus;
using PayriffIntegration.Models.CardRegister;

namespace BankIntegration.Interfaces;

public interface IPayriffService
{
    Task<CreateResponseModel?> Create(CreateRequestModel requset);
    Task<GetStatusResponseModel?> GetStatus(GetStatusRequestModel requset); 
}