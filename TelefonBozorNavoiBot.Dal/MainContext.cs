using Microsoft.EntityFrameworkCore;
using TelefonBozorNavoiBot.Dal.Entities;
using TelefonBozorNavoiBot.Dal.EntityConfiguration;
using TelefonBozorNavoiBot.Dal.EntityConfigurations;

namespace TelefonBozorNavoiBot.Dal;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BotUser> Users { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
        

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var connectionString = "Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=TelefonBozorNavoiBot;TrustServerCertificate=True;";
    //        optionsBuilder.UseSqlServer(connectionString);
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BotUserConfiguration());
        modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
    }
}
