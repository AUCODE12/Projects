namespace HotelBookingSystem.Dal.Entities;

public class Service
{
    public long ServiceId { get; set; }
    public string ServiceName { get; set; }
    public decimal Price { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
