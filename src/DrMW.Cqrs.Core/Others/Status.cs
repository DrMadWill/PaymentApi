
using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Others;

public class Status : Enumeration
{
    public static Status Succeed = new(1, "Succeed");
    public static Status Failed = new (2, "Failed");

    public Status(int id, string name) : base(id, name)
    {

    }

}