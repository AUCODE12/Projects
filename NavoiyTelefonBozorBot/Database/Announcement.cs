using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NavoiyTelefonBozorBot.Database;

public class Announcement
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public UserTg User { get; set; }

    public string ImageUrl { get; set; }
    public string PhoneModel { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsSold { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}