namespace HotelBookingSystem.Dal.Entities;

public class Booking
{
    public long BookingId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public long RoomId { get; set; }
    public Room Room { get; set; }
    public Payment Payment { get; set; }
}
