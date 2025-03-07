namespace TelefonBozorNavoiBot.Dal.Entities;

public class Announcement
{
    public long AnnouncementId { get; set; }
    public string ImageUrl { get; set; }
    public string PhoneModel { get; set; }
    public int BatteryCapacity { get; set; } // Batareya sig‘imi (mAh)
    public int BatteryHealth { get; set; } // iPhone uchun batareya sog‘lig‘i (%)
    public int RAM { get; set; } // Tezkor xotira (GB)
    public int Storage { get; set; } // Ichki xotira (GB)
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsSold { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;


    public long BotUserId { get; set; }
    public BotUser BotUser { get; set; }
}
