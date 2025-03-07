using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TelefonBozorNavoiBot.Dal.Entities;

namespace TelefonBozorNavoiBot.Dal.EntityConfigurations;

public class BotUserConfiguration : IEntityTypeConfiguration<BotUser>
{
    public void Configure(EntityTypeBuilder<BotUser> builder)
    {
        builder.ToTable("User");

        builder.HasKey(b => b.BotUserId);

        builder.Property(b => b.TelegramUserId)
            .IsRequired();

        builder.Property(b => b.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.LastName)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(b => b.Username)
            .IsRequired(false)
            .HasMaxLength(50);

        builder.Property(b => b.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(b => b.IsBlocked)
            .IsRequired();
    }
}
