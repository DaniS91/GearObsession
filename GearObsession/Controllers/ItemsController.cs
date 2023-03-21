using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GearObsession.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GearObsession.Controllers
{
  public class ItemsController : Controller
  {
    private readonly GearObsessionContext _db;

    public ItemsController(GearObsessionContext db)
    {
      _db = db;
    }

    public ActionResult Index(string sortOrder)
    {
      ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
      ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
      ViewBag.WeightSortParm = sortOrder == "Weight" ? "weight_desc" : "Weight";
      ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
      var items = (from s in _db.Items
                  .Include(s => s.Category)
                  select s);

      switch (sortOrder)
        {
          case "Name":
            items = items.OrderBy(s => s.Name);
            break;
          case "name_desc":
            items = items.OrderByDescending(s => s.Name);
            break;
          case "Brand":
            items = items.OrderBy(s => s.Brand);
            break;
          case "brand_desc":
            items = items.OrderByDescending(s => s.Brand);
            break;
          case "Weight":
            items = items.OrderBy(s => s.Weight);
            break;
          case "weight_desc":
            items = items.OrderByDescending(s => s.Weight);
            break;
          case "Price":
            items = items.OrderBy(s => s.Price);
            break;
          case "price_desc":
            items = items.OrderByDescending(s => s.Price);
            break;
          default:
            items = items.OrderBy(s => s.ItemId);
            break;
        }
        
      return View(items.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item)
    {
      if (!ModelState.IsValid)
      {
          ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
          return View(item);
      }
      else
      {
        _db.Items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items
                          .Include(item => item.Category)
                          .Include(item => item.JoinEntities)
                          .ThenInclude(join => join.User)
                          .FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }
    


    public ActionResult Edit(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item)
    {
      _db.Items.Update(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
     public ActionResult AddUser(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.UserId = new SelectList(_db.Users, "UserId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddUser(Item item, int userId)
    {
      #nullable enable
      ItemUser? joinEntity = _db.ItemUsers.FirstOrDefault(join => (join.UserId == userId && join.ItemId == item.ItemId));
      #nullable disable
      if (joinEntity == null && userId != 0)
      {
        _db.ItemUsers.Add(new ItemUser() { UserId = userId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = item.ItemId });
    }  

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //   ItemUser joinEntry = _db.ItemUsers.FirstOrDefault(entry => entry.ItemUserId == joinId);
    //   _db.ItemUsers.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    [HttpPost]
    public ActionResult DeleteItemFromUser(int joinId, int userId)
    {
      ItemUser joinEntry = _db.ItemUsers.FirstOrDefault(entry => entry.ItemUserId == joinId);
      _db.ItemUsers.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", "Users", new {id = userId});
    }
  }
}