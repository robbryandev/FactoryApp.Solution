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

    [HttpGet("/machine/delete/{id}")]
    public ActionResult Delete(int id) {
      Machine thisMachine = _db.Machines.FirstOrDefault(mac => mac.machine_id == id);
      return View(thisMachine);
    }

    [HttpPost("/machine/delete/{id}")]
    public ActionResult DeleteConfirm(int id) {
      Machine thisMachine = _db.Machines.FirstOrDefault(mac => mac.machine_id == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return Redirect("/machine");
    }
  }
}