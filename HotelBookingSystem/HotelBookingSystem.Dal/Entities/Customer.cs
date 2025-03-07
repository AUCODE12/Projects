namespace HotelBookingSystem.Dal.Entities;

public class Customer
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Complaint> Complaints { get; set; }
}
