using System.ComponentModel.DataAnnotations;

namespace NavoiyTelefonBozorBot.Database;

public class UserTg
{
    [Key]
    public int Id { get; set; }
    public long TelegramId { get; set; }
    public string? FullName { get; set; }
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public string Language { get; set; } = "uz";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
