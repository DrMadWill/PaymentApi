using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Others;

public class Currency : Enumeration
{
    public static Currency USD = new(1, "USD");
    public static Currency AZN = new(2, "AZN");
    public Currency(int id, string name) : base(id, name)
    {
    }
}
