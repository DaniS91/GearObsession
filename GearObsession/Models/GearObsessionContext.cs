using Microsoft.EntityFrameworkCore;

namespace GearObsession.Models
{
  public class GearObsessionContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ItemUser> ItemUsers { get; set; }
    public GearObsessionContext(DbContextOptions options) : base(options) { }
  }
}