using System.Collections.Generic;

namespace GearObsession.Models
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Item> Items { get; set; }
  }
}