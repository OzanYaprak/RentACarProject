using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Model : Entity<Guid>
{
    #region Constructors

    public Model(Guid id, int brandId, int fuelId, int transmissionId, string name, decimal dailyPrice, string imageUrl) : this()
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
    }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    #endregion
    
    #region Properties

    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; } = String.Empty;
    
    #endregion

    #region Navigation Properties

    public virtual Brand? Brand { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public virtual Transmission? Transmission { get; set; }


    /// <summary>
    /// Bu Model'e ait araç koleksiyonu.
    /// - Varsayılan olarak bir <see cref="HashSet{Car}"/> ile başlatılır, böylece koleksiyon null olmaz.
    /// - <see cref="HashSet{T}"/> aynı öğenin tekrar eklenmesini engeller (benzersizlik sağlar).
    /// - Add / Contains / Remove işlemleri ortalama O(1) zaman karmaşıklığına sahiptir (hızlıdır).
    /// - EF Core gibi ORM'lerle çalışırken koleksiyon üzerinde önceden ekleme/silme yapılmasına izin verir.
    /// Not: Sıralama veya indeksleme gerekiyorsa <see cref="List{T}"/> tercih edilebilir.
    /// </summary>
    public virtual ICollection<Car> Cars { get; set; }

    #endregion

}
