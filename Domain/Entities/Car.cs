using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    #region Constructors
    
    public Car(Guid id, Guid modelId, int kilometer, short modelYear, string plate, short minFindexScore, CarState carState) : this()   
    {
        Id = id;
        ModelId = modelId;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindexScore = minFindexScore;
        CarState = carState;
    }

    public Car()
    {
    }

    #endregion

    #region Properties

    public Guid ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; } = String.Empty;
    public short MinFindexScore { get; set; }
    public CarState CarState { get; set; }

    #endregion

    #region Navigation Properties

    public virtual Model? Model { get; set; }

    #endregion
}