#pragma warning disable CS8618
#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8629
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;
[SessionCheck]
public class WeddingController : Controller
{
  private readonly ILogger<WeddingController> _logger;
  private MyContext db;

  public WeddingController(ILogger<WeddingController> logger, MyContext context)
  {
    _logger = logger;
    db = context;
  }

  //view all
  [HttpGet("wedding")]
  public IActionResult AllWedding()
  {
    List<Wedding> allWedding = db.Weddings
      .Include(wedding => wedding.Creator)
      .Include(wedding => wedding.AllRsvps)
      .ToList();
    return View("AllWedding", allWedding);
  }

  [HttpGet("wedding/new")]
  public IActionResult NewWedding()
  {
    return View("New");
  }

  //create wedding
  [HttpPost("wedding/create")]
  public IActionResult CreateWedding(Wedding newWedding)
  {
    if (!ModelState.IsValid)
    {
      return View("New");
    }

    newWedding.UserId = (int)HttpContext.Session.GetInt32("UUID");

    db.Weddings.Add(newWedding);
    db.SaveChanges();
    return RedirectToAction("AllWedding");
  }

// Get one Wedding
  [HttpGet("wedding/{WeddingId}")]
  public IActionResult ViewOne(int weddingId)
  {
    Wedding? oneWedding = db.Weddings
        .Include(wedding => wedding.AllRsvps)
        .ThenInclude(rsvp => rsvp.User)
        .FirstOrDefault(wedding => wedding.WeddingId == weddingId);

    if (oneWedding == null)
    {
      return RedirectToAction("Index");
    }
    return View("Details", oneWedding);
  }

  //edit wedding
  [HttpGet("wedding/{WeddingId}/edit")]
  public IActionResult EditWedding(int weddingId)
  {
    Wedding? oneWedding = db.Weddings
        .FirstOrDefault(wedding => wedding.WeddingId == weddingId);

    if (oneWedding == null)
    {
      return RedirectToAction("Index");
    }
    return View("Edit", oneWedding);
  }

  [HttpPost("/wedding/{weddingId}/update")]
  public IActionResult UpdateWedding(int weddingId, Wedding editedWedding)
  {
    if(!ModelState.IsValid)
    {
      return EditWedding(weddingId);
    }

    Wedding? dbWedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == weddingId);

    if(dbWedding == null)
    {
      return RedirectToAction("AllWedding");
    }
    dbWedding.WedderOne = editedWedding.WedderOne;
    dbWedding.WedderTwo = editedWedding.WedderTwo;
    dbWedding.Date = editedWedding.Date;
    dbWedding.Address = editedWedding.Address;
    dbWedding.UpdatedAt = DateTime.Now;

    db.SaveChanges();
    return RedirectToAction("ViewOne", new { weddingId = weddingId});

  }


  //delete
  [HttpPost("/wedding/{weddingId}/delete")]
  public IActionResult DeleteWedding(int weddingId)
  {
    Wedding? wedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == weddingId);

    if(wedding != null)
    {
      db.Weddings.Remove(wedding);
      db.SaveChanges();
    }
    return RedirectToAction("AllWedding");
  }

  //many to many
  [HttpPost("wedding/{weddingId}/rsvp")]
  public IActionResult Rsvp(int weddingId)
  {
    
    RSVP? existingRSVP = db.RSVPs.FirstOrDefault(rsvp => rsvp.UserId == 
    HttpContext.Session.GetInt32("UUID") && rsvp.WeddingId == weddingId);

    if (existingRSVP == null)
    {
      RSVP newRsvp = new RSVP()
      {
        WeddingId = weddingId,
        UserId = (int)HttpContext.Session.GetInt32("UUID")
      };

      db.RSVPs.Add(newRsvp);
    }
    else 
    {
      db.RSVPs.Remove(existingRSVP);
    }

    db.SaveChanges();
    return RedirectToAction("AllWedding");


  }

}

public class SessionCheckAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
      int? userId = context.HttpContext.Session.GetInt32("UUID");
      if (userId == null)
      {
        context.Result = new RedirectToActionResult("Index", "Home", null);
      }
  }
}