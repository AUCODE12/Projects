namespace HotelBookingSystem.Dal.Entities;

public class Complaint
{
    public long ComplaintId { get; set; }
    public string Massage { get; set; }
    public string Status { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}