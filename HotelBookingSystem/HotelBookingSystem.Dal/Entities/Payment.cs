namespace HotelBookingSystem.Dal.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public long BookingId { get; set; }
    public Booking Booking { get; set; }
}
