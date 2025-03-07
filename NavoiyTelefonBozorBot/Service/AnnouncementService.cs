using NavoiyTelefonBozorBot.Database;

namespace NavoiyTelefonBozorBot.Service;

public class AnnouncementService
{
    private readonly AppDbContext _db;

    public AnnouncementService(AppDbContext db)
    {
        _db = db;
    }

    public void AddAnnouncement(Announcement announcement)
    {
        _db.Announcements.Add(announcement);
        _db.SaveChanges();
    }

    public void MarkAsSold(int announcementId)
    {
        var announcement = _db.Announcements.FirstOrDefault(a => a.Id == announcementId);
        if (announcement != null)
        {
            announcement.IsSold = true;
            _db.SaveChanges();
        }
    }
}
