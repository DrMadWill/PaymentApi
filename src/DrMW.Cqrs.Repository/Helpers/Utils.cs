using Newtonsoft.Json;

namespace DrMW.Cqrs.Repository.Helpers;

public static class Utils
{
    
    
    public static string JsonString(this object obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }
}