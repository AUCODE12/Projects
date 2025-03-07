namespace HotelBookingSystem.Dal.Entities;

public class Room
{
    public long RoomId { get; set; }
    public string RoomType { get; set; }
    public decimal Price { get; set; }
    public bool Availability { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public Booking Booking { get; set; }
}
