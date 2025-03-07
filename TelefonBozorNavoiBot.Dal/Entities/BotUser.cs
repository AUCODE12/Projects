namespace TelefonBozorNavoiBot.Dal.Entities;

public class BotUser
{
    public long BotUserId { get; set; }
    public long TelegramUserId { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsBlocked { get; set; } = false;

    public ICollection<Announcement>? Announcements { get; set; } = new List<Announcement>();
}
