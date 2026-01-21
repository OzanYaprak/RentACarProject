using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity<Guid>
{
    public Brand() { }
    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; } = null!;
}
