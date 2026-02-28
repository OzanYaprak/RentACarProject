namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDTO
{
    public Guid Id { get; set; }
    public String? BrandName { get; set; }
    public String? FuelName { get; set; }
    public String? TransmissionName { get; set; }
    public String? Name { get; set; }
    public Decimal DailyPrice { get; set; }
    public String? ImageUrl { get; set; }
}
