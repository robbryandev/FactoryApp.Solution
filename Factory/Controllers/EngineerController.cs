using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;
    public EngineerController(FactoryContext db)
    {
      _db = db;
    }
    
    [HttpGet("/engineer")]
    public ActionResult Index() {
      List<Engineer> allEngineers = _db.Engineers.ToList();
      return View(allEngineers);
    }

    [HttpGet("/engineer/add")]
    public ActionResult Add() {
      return View();
    }

    [HttpPost("/engineer/add")]
    public ActionResult AddConfirm(Engineer engineer) {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return Redirect("/engineer");
    }
  }
}