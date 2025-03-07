using HotelBookingSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Dal;

public class MainContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Complaint> Complaints { get; set; }
    
    public MainContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
