using pt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Diagnostics;

namespace pt.Controllers
{
    public class HomeController : Controller
    {
        PContext db = new PContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowPirates(int? page)
        {         
                return View(db.Pirates.ToList().ToPagedList(page??1, 3));
        }

        public ActionResult ShowShips()
        {
            return View(db.Ships.ToList());
        }
        public ActionResult ShowCrew()
        {
            return View(db.Crews.ToList()); 
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Create(Pirate p)
        {
            if (ModelState.IsValid)
            {
                db.Pirates.Add(p);
                db.SaveChanges();
                return RedirectToAction("ShowPirates");
            }
            return View(p);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest);}
            Pirate p = db.Pirates.Find(id);
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Pirate p = db.Pirates.Find(id);
            if (p == null) { return HttpNotFound();}

            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int? id, DateTime Date)
        {
            Pirate p = db.Pirates.Find(id);
            if(TryUpdateModel(p,"",new string[] {"Name","Date" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("ShowPirates");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("","not be able to save the changes");
                }
            }
            return View(p);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pirate p = db.Pirates.Find(id);
            if (p == null) return HttpNotFound();
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int? id, Pirate p1)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Pirate p = db.Pirates.Find(id);
            try
            {
               
                db.Pirates.Remove(p);
                db.SaveChanges();
                return RedirectToAction("ShowPirates");
            }
            catch (Exception) { ModelState.AddModelError("","not able to delete this record"); }
            return View(p);
        }

        public ActionResult Booty()
        {
            //var plist = db.Pirates.ToList();
            //decimal total = 0;
            //List<dynamic> totalList = new List<dynamic>();
            //foreach (var ps in plist)
            //{
            //    total = 0;
            //    foreach (var c in db.Crews.Where(x => x.PirateId == ps.id))
            //    {
            //        total += c.Booty;
            //    }
            //    var jobj = new
            //    {
            //        booty = total,
            //        name = ps.Name
            //    };
            //    totalList.Add(jobj);

            //}
            //var sorted = totalList.OrderByDescending(x => x.booty);
            //return Json(sorted, JsonRequestBehavior.AllowGet);
            var jsonList = db.Pirates.Select(p => new { name = p.Name, booty = (decimal?)p.Crews.Select(x => x.Booty).Sum()??0}).OrderByDescending(p => p.booty);
            return Json(jsonList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult JaxCreate(Object json)
        //{
        //    Debug.WriteLine(json.ToString().Length);

        //    return Json(db.Pirates.ToList(),JsonRequestBehavior.AllowGet);
        //}



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}