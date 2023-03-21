using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace GearObsession.Models
{
  public class Item
  {
    public int ItemId { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string Description {get; set; }

    public int Weight { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public List<ItemUser> JoinEntities { get; }
  }
}