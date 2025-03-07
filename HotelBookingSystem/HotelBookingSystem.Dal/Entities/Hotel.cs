namespace HotelBookingSystem.Dal.Entities;

public class Hotel
{
    public long HotelId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Service> Services { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Complaint> Complaints { get; set; }
}
