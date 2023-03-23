using System.Collections.Generic;
using System;

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

    public List<PieChartData> getPieChart(){
      //Create List<PieChartData>
      List<PieChartData> output = new List<PieChartData>();

      //Pull the list of items associated with the user
      List<Item> itemList = new List<Item>();
      foreach (ItemUser join in this.JoinEntities){
        itemList.Add(join.Item);
      }

      //From the list of items, create a list of categories  (xValue and text property)
      List<string> categoryList = new List<string>();
      foreach (Item thisItem in itemList)
      {
        //get CategoryId property from this Item
        int catId = thisItem.CategoryId;
        string catName = thisItem.Category.Name;
        //Add name to categoryList
        if (!categoryList.Contains(catName))
        {
          categoryList.Add(catName);
        }
      }

      //Create PieChartData objects for each category 
      foreach (string categoryName in categoryList)
      {
        var random = new Random();
        var color = String.Format("#{0:X6}", random.Next(0x1000000)); // = "#A197B9"
        PieChartData temp = new PieChartData {xValue = categoryName, yValue = 0, text = categoryName, fill = "color"};
        output.Add(temp);
      }

      //Add up the weight of each item per category (yValue property)
      foreach (Item thisItem in itemList)
      {
        int weight = thisItem.Weight;
        foreach (PieChartData categorySlice in output)
        {
          if (thisItem.Category.Name == categorySlice.xValue)
          {
            categorySlice.yValue += weight;
          }
        }
      }
      //Export List
      return output;
    }
  }

  
}