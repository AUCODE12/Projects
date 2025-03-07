using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TelefonBozorNavoiBot.Dal.Entities;

namespace TelefonBozorNavoiBot.Dal.EntityConfiguration;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcement");

        builder.HasKey(a => a.AnnouncementId);

        builder.Property(a => a.ImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.PhoneModel)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.BatteryCapacity)
            .IsRequired();

        builder.Property(a => a.BatteryHealth)
            .IsRequired();

        builder.Property(a => a.RAM)
            .IsRequired();

        builder.Property(a => a.Storage)
            .IsRequired();

        builder.Property(a => a.Description)
            .HasMaxLength(1000);

        builder.Property(a => a.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(a => a.IsSold)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.HasOne(a => a.BotUser)
            .WithMany(b => b.Announcements)
            .HasForeignKey(a => a.BotUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

