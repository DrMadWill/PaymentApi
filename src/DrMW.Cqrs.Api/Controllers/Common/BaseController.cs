using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrMW.Cqrs.Api.Controllers.Common;
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    
    
   
}