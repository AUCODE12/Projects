namespace HotelBookingSystem.Dal.Entities;

public class Employee
{
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
}
