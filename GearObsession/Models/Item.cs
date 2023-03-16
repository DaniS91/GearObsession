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

   

    // public int Weight { get; set; }
    private int _Weight; //private field
    public int Weight //public property
    {
    get // a property accessor used to return the property value
    {
        return _Weight; 
    }
    set // a property accessor used to assign a new value
    {
      string input = value;
        _Weight = Int32.Parse(input);
    }
    }

    public decimal Price { get; set; }

    //Categories
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    //JoinEtity
    public List<ItemUser> JoinEntities { get; }

    public void convertSomething()
    {

    }
  }
}