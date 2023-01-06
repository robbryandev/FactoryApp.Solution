using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly FactoryContext _db;
    public MachineController(FactoryContext db)
    {
      _db = db;
    }
    
    [HttpGet("/machine")]
    public ActionResult Index() {
      List<Machine> allMachines = _db.Machines.ToList();
      return View(allMachines);
    }

    [HttpGet("/machine/add")]
    public ActionResult Add() {
      return View();
    }

    [HttpPost("/machine/add")]
    public ActionResult AddConfirm(Machine machine) {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return Redirect("/machine");
    }
  }
}