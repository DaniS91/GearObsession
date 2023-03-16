using Microsoft.AspNetCore.Mvc;
using GearObsession.Models;
using System.Collections.Generic;
using System.Linq;

namespace GearObsession.Controllers
{
  public class HomeController : Controller
  {
    private readonly GearObsessionContext _db;

    public HomeController(GearObsessionContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Category[] cats = _db.Categories.ToArray();
      Item[] items = _db.Items.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("categories", cats);
      model.Add("items", items);
      return View(model);
    }
  }
}