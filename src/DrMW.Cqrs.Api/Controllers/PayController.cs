using BankIntegration.Interfaces;
using BankIntegration.Models.Create;
using DrMW.Cqrs.Core.PaymentRequests;
using DrMW.Cqrs.Models.Requests;
using DrMW.Cqrs.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DrMW.Cqrs.Api.Controllers;

public class PayController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IPayriffService _payriffService;
    public PayController(IPaymentService paymentService, IPayriffService payriffService)
    {
        _paymentService = paymentService;
        _payriffService = payriffService;
    }
    
    [HttpPost]
    public async Task<IActionResult> OneTimePayment(PayRequest request)
    {
        await _paymentService.AddAsync(request);
        var result = await _payriffService.Create(new CreateRequestModel
        {
            Amount = request.Amount,
            ResultURL = "" + $"/Payriff/CreateSuccess/{request.OrderId}",
            CancelURL = "" + $"/Payriff/CreateCancel/{request.OrderId}",
            DeclineURL = "" + $"/Payriff/CreateDecline/{request.OrderId}",
            Language = "AZ",
            DirectPay = true,
            InstallmentPeriod = 0,
            InstallmentProductType = "BIRKART",
        });
        
        return Ok(new { success = true, link = result.Payload.PaymentUrl });
    }
}