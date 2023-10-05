#pragma warning disable CS0649

namespace Karami.Domain.Permission.Entities;

public class Permission
{
    public string Id   { get; private set; }
    public string Name { get; private set; }

    public Permission(string id, string name)
    {
        Id   = id;
        Name = name;
    }
}