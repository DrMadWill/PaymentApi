using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Banks;

public class Bank : BaseEntity<int>
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    
    
}