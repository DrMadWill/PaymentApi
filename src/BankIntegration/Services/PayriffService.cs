using BankIntegration.Interfaces;
using BankIntegration.Models;
using BankIntegration.Models.Create;
using BankIntegration.Models.GetStatus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BankIntegration.Services;

public class PayriffService : IPayriffService
{
    private readonly PayriffConfiguration _configuration;
    private readonly ILogger<PayriffService> _logger;
    public PayriffService(PayriffConfiguration configuration, ILogger<PayriffService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
   

    public async Task<CreateResponseModel?> Create(CreateRequestModel requset)
        => await Operation<CreateRequestModel, CreateResponseModel>(requset, "createOrder");
 

    public async Task<GetStatusResponseModel?> GetStatus(GetStatusRequestModel requset)
        => await Operation<GetStatusRequestModel, GetStatusResponseModel>(requset, "getOrderInformation");

    #region Extation

    private async Task<TResponse?> Operation<TRequest, TResponse>(TRequest request,string link)
        where TRequest : class
        where TResponse : class
    {
        try
        {
            var response = await SendRequest(request, link);
            return string.IsNullOrEmpty(response) ? null : 
                JsonConvert.DeserializeObject<TResponse>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.LogError("Payment Error | From : {0} | Params : {1} ",link,JsonConvert.SerializeObject(request));
            return null;
        }
    }
    
    private async Task<string> SendRequest(object paramters,string method) 
    {
        using var httpClient = new HttpClient();
        // default json
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("Authorization",_configuration.SecretKey);
        // Generate string params
        var data = GenerateData(paramters);
        // create content
        var content = new StringContent(data, null, "application/json");
        using var cancellationToken = new CancellationTokenSource(new TimeSpan(0, 5, 0));
        var response = await httpClient.PostAsync(_configuration.BaseApiUrl + method, content, cancellationToken.Token);

        if (!response.IsSuccessStatusCode) return "";
        var str = await response.Content.ReadAsStringAsync(cancellationToken.Token);
        // content read
        return str;

    }

    string GenerateData(object request)
        => JsonConvert.SerializeObject(new BaseRequestModel
        {
            Merchant = _configuration.Merchant,
            Body = request
        });
    #endregion
}