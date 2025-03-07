using Microsoft.EntityFrameworkCore;

namespace NavoiyTelefonBozorBot.Database;

public class AppDbContext : DbContext
{
    public DbSet<UserTg> Users { get; set; }
    public DbSet<Announcement> Announcements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=NavoiyTelefonBozorBot;TrustServerCertificate=True;");
    }
}
