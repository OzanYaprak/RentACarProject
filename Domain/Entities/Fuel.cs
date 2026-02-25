using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Fuel : Entity<Guid>
{
    #region Constructors

    public Fuel() { Models = new HashSet<Model>(); }
    public Fuel(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }

    #endregion

    #region Properties

    public string Name { get; set; } = String.Empty;

    #endregion

    #region Navigation Properties

    public virtual ICollection<Model> Models { get; set; }

    #endregion
}
