namespace HotelBookingSystem.Dal.Entities;

public class Review
{
    public long ReviewId { get; set; }
    public decimal? Rating { get; set; }
    public string Comment { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
