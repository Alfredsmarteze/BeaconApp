using BeaconApp.Data;
using BeaconApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeaconApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeaconContext _beaconContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(BeaconContext beaconContext,ILogger<HomeController> logger)
        {
            _beaconContext = beaconContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetData()
        {
            List<IBS_Currency> iBs = new List<IBS_Currency>();
            //iBs = _beaconContext.IBS_Currencies.Select(s => s).ToList();//<IBS_Currency>();
            iBs= _beaconContext.IBS_Currencies.ToList<IBS_Currency>();
            return Json(new { data = iBs });
            //, System.Web.Mvc.JsonRequestBehavior.AllowGet
        }
        
        [HttpGet]
        public IActionResult AddorEdit(int Id=0)
        {
            

            if (Id == 0)
            {
                return View(new IBS_Currency());
            }
            else
            {
                IBS_Currency ret = _beaconContext.IBS_Currencies.Where(s => s.ID == Id).FirstOrDefault<IBS_Currency>();
                return View(ret);
            }
            
             
        }

        [HttpPost]
        public IActionResult AddorEdit( IBS_Currency iBS_Currency)
        {
            int upd = iBS_Currency.ID;
            if (upd > 0)
            {
                _beaconContext.Entry(iBS_Currency).State =EntityState.Modified;
                _beaconContext.SaveChanges();
                ViewData["updated"] = "Updated Successfully.";
                ModelState.Clear();
                //return View("Index");
                return Json(new { success = true, message = "Updated successfully" });
            }
            else if(upd==0 ||upd<0)
            {
                if (ModelState.IsValid)
                {
                    _beaconContext.IBS_Currencies.Add(iBS_Currency);
                    _beaconContext.SaveChanges();
                     ModelState.Clear();
                    ViewData["saved"] = "Saved Successfully.";
                }
                
            }
            // return RedirectToAction("Index");
            return Json(new { success = true, message = "Saved successfully" });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                IBS_Currency retId = _beaconContext.IBS_Currencies.Where(s => s.ID == id).FirstOrDefault<IBS_Currency>();
                _beaconContext.IBS_Currencies.Remove(retId);
                _beaconContext.SaveChanges();
                ModelState.Clear();
              ViewData["deleted"] = "Record deleted Successfully.";
             //return View("Index");
            }
            //return View("Index");
            return Json(new { success = true, message = "Deleted successfully" });//,message = "Deleted successfully" }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
