using System.Text;
using Application.Features.Commands.Payriff.Create.CreateDecline;
using DrMW.Cqrs.Api.Controllers.Common;
using DrMW.Cqrs.Repository.Helpers;
using DrMW.Cqrs.Service.Features.Command.Payriff.Cancel;
using DrMW.Cqrs.Service.Features.Command.Payriff.Success;
using DrMW.Cqrs.Service.Features.Query.GetLink;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[AllowAnonymous]
public class PayriffController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<PayriffController> _logger;

    public PayriffController(IMediator mediator, ILogger<PayriffController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }


    [HttpPost("CreateSuccess/{orderId:guid}")]
    public async Task<IActionResult> CreateSuccess([FromQuery] Guid orderId)
    {
        using var sr = new StreamReader(Request.Body);
        var body = await sr.ReadToEndAsync();
        _logger.LogInformation("header : {headers} | body : {body}", GetReqs(Request.Headers),
            new { body, orderId }.JsonString());
        try
        {
            var req = JsonConvert.DeserializeObject<CreateSuccessReq>(body);
            
            req.OrderId = orderId;
            await _mediator.Send(req);
        }
        catch (Exception e)
        {
            _logger.LogError("CreateSuccess error : {e}", e);
        }


        return Ok();
    }

    [HttpGet("CreateSuccess/{orderId:guid}")]
    public async Task<IActionResult> GetCreateSuccess(Guid orderId)
        => await GetLink(orderId,true);
    
    
    
    
    [HttpPost("CreateCancel/{orderId:guid}")]
    public async Task<IActionResult> CreateCancel(Guid orderId)
    {
        using var sr = new StreamReader(Request.Body);
        var body = await sr.ReadToEndAsync();
        _logger.LogInformation("header : {headers} | body : {body}", GetReqs(Request.Headers),
            new { body, orderId }.JsonString());
        try
        {
            await _mediator.Send(new CreateCancelReq
            {
                OrderId = orderId,
                Content = body
            });
        }
        catch (Exception e)
        {
            _logger.LogError("CreateSuccess error : {e}", e);
        }

        return Ok();
    }

    [HttpGet("CreateCancel/{orderId:guid}")]
    public async Task<IActionResult> GetCreateCancel(Guid orderId)
        => await GetLink(orderId);


    
    
    [HttpPost("CreateDecline/{orderId:guid}")]
    public async Task<IActionResult> CreateDecline(Guid orderId)
    {
        using var sr = new StreamReader(Request.Body);
        var body = await sr.ReadToEndAsync();
        _logger.LogInformation("header : {headers} | body : {body}", GetReqs(Request.Headers),
            new { body, orderId }.JsonString());
        try
        {
            await _mediator.Send(new CreateDeclineReq
            {
                OrderId = orderId,
                Content = body
            });
        }
        catch (Exception e)
        {
            _logger.LogError("CreateSuccess error : {e}", e);
        }

        return Ok();
    }

    [HttpGet("CreateDecline/{orderId:guid}")]
    public async Task<IActionResult> GetCreateDecline(Guid orderId)
        => await GetLink(orderId);
    
    
    
    
    
    private async Task<IActionResult> GetLink(Guid orderId, bool success = false)
    {
        Console.WriteLine(" =>>>>>> Status : " +  success);
        var link = await _mediator.Send(new GetLinkReq { Token = orderId, Success = success });
        return Redirect(string.IsNullOrEmpty(link) ? "" : link);
    }

    private string GetReqs(IHeaderDictionary headerDictionary)
    {
        StringBuilder headers = new StringBuilder();
        headers.Append("{");
        foreach (var item in headerDictionary)
        {
            headers.Append("'" + item.Key + ":" + ":" + "'" + item.Value + "'");
        }

        headers.Append("}");
        return headers.ToString();
    }
}