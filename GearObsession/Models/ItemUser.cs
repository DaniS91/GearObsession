namespace GearObsession.Models
{
  public class ItemUser
  {
    public int ItemUserId { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
  }
}