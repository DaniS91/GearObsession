using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;
using GearObsession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace GearObsession.Controllers
{
  public class UsersController : Controller
  {
    private readonly GearObsessionContext _db;

    public UsersController(GearObsessionContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Users.ToList());
    }

    public ActionResult Details(int id)
    {
      User thisUser = _db.Users
          .Include(user => user.JoinEntities)
          .ThenInclude(join => join.Item)
          .FirstOrDefault(user => user.UserId == id);
      ViewBag.TotalWeight = thisUser.getTotalWeight();

      List<Category> catList = _db.Categories.ToList();
      ViewBag.dataSource = thisUser.getPieChart();
      
      return View(thisUser);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddItem(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Name");
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult AddItem(User user, int itemId)
    {
#nullable enable
      ItemUser? joinEntity = _db.ItemUsers.FirstOrDefault(join => (join.ItemId == itemId && join.UserId == user.UserId));
#nullable disable
      if (joinEntity == null && itemId != 0)
      {
        _db.ItemUsers.Add(new ItemUser() { ItemId = itemId, UserId = user.UserId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = user.UserId });
    }

    public ActionResult Edit(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      return View(thisUser);
    }

    [HttpPost]
    public ActionResult Edit(User user)
    {
      _db.Users.Update(user);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      return View(thisUser);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      User thisUser = _db.Users.FirstOrDefault(users => users.UserId == id);
      _db.Users.Remove(thisUser);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      ItemUser joinEntry = _db.ItemUsers.FirstOrDefault(entry => entry.ItemUserId == joinId);
      _db.ItemUsers.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  
  }
}