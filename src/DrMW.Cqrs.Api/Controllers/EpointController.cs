using DrMW.Cqrs.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DrMW.Cqrs.Api.Controllers;

public class EpointController : ControllerBase
{
    public async Task<IActionResult> Result()
    {
        using var sw = new StreamReader(Request.Body);
        var bodyString = await sw.ReadToEndAsync();
        var body = JsonConvert.DeserializeObject<EpointPaymentResult>(bodyString);
        
        
        
        return Ok();
    }
}