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

    [HttpGet("/engineer/delete/{id}")]
    public ActionResult Delete(int id) {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.engineer_id == id);
      return View(thisEngineer);
    }

    [HttpPost("/engineer/delete/{id}")]
    public ActionResult DeleteConfirm(int id) {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(eng => eng.engineer_id == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return Redirect("/engineer");
    }
  }
}