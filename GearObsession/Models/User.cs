using System.Collections.Generic;

namespace GearObsession.Models
{
  public class User
  {
    public int UserId { get; set; }

    public string Name { get; set; }
    //Items
    public List<ItemUser> JoinEntities { get; }

    public int getTotalWeight(){
      int x = 0;
      foreach (ItemUser join in this.JoinEntities){
        x+= join.Item.Weight;
      }
      return x;
    }
  }
}