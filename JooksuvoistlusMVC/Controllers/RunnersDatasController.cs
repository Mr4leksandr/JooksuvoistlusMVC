using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JooksuvoistlusMVC.Models;

namespace JooksuvoistlusMVC.Controllers
{
    public class RunnersDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost, ActionName("RemoveRunner")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveRunnerConfirmed(int id)
        {
            RunnersData runnersData = db.RunnersDatas.Find(id);
            db.RunnersDatas.Remove(runnersData);
            db.SaveChanges();
            return RedirectToAction("RunnersList");
        }

        //public ActionResult FirstPlaces()
        //{
        //    var best = db.RunnersDatas
        //        .Where(r => r.Break == true)
        //        .OrderBy(r => r.FinishTime)
        //        .ToList();
        //    return View(best.First());
        //}

        [Authorize]
        public ActionResult RemoveRunner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnersData runnersData = db.RunnersDatas.Find(id);
            if (runnersData == null)
            {
                return HttpNotFound();
            }
            return View(runnersData);
        }

        [Authorize]
        public ActionResult EditRunner(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnersData runnersData = db.RunnersDatas.Find(id);
            if (runnersData == null)
            {
                return HttpNotFound();
            }
            return View(runnersData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRunner([Bind(Include = "Id,FirstName,LastName,StartingTime,FinishTime,Break")] RunnersData runnersData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runnersData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RunnersList");
            }
            return View(runnersData);
        }

        //public ActionResult AwardingList()
        //{
        //    var model = db.RunnersDatas
        //        .Where(r => r.Break == true)
        //        .OrderBy(r => r.FinishTime)
        //        .ToList();
        //    return View(model);
        //}

        public ActionResult Race()
        {
            return View(db.RunnersDatas.ToList());
        }

        public ActionResult RunnersList()
        {
            return View(db.RunnersDatas.ToList());
        }

        public ActionResult FinishTime(RunnersData runnersData)
        {
            var model = db.RunnersDatas
                .Where(r => r.FinishTime == null)
                .ToList();

            runnersData.FinishTime = DateTime.Now;
            db.Entry(runnersData).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Race");
        }

        public ActionResult SecondBreak(RunnersData runnersData)
        {
            var model = db.RunnersDatas
                .Where(r => r.SecondBreak == null)
                .ToList();

            runnersData.SecondBreak = DateTime.Now;
            db.Entry(runnersData).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Race");
        }

        public ActionResult FirstBreak(RunnersData runnersData)
        {
            if (runnersData.StartingTime == null)
            {
                return RedirectToAction("Race");
            }
            else if (runnersData.StartingTime != null)
            {
                var model = db.RunnersDatas
                    .Where(r => r.FirstBreak == null)
                    .ToList();

                runnersData.FirstBreak = DateTime.Now;
                db.Entry(runnersData).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Race");
        }

        public ActionResult StartRace()
        {
            var model = db.RunnersDatas
                .Where(r => r.StartingTime == null)
                .ToList();
            foreach (var runnersData in model)
            {
                runnersData.StartingTime = DateTime.Now;
                db.Entry(runnersData).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Race");
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: RunnersDatas
        public ActionResult Index()
        {
            return View(db.RunnersDatas.ToList());
        }

        // GET: RunnersDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnersData runnersData = db.RunnersDatas.Find(id);
            if (runnersData == null)
            {
                return HttpNotFound();
            }
            return View(runnersData);
        }

        // GET: RunnersDatas/Create
        public ActionResult CreateRunner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRunner(RunnersData runnersData)
        {
            if (ModelState.IsValid)
            {
                db.RunnersDatas.Add(runnersData);
                db.SaveChanges();
                return RedirectToAction("RunnersList");
            }

            return View(runnersData);
        }

        // POST: RunnersDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StartingTime,FinishTime")] RunnersData runnersData)
        {
            if (ModelState.IsValid)
            {
                db.RunnersDatas.Add(runnersData);
                db.SaveChanges();
                return RedirectToAction("Participants");
            }

            return View(runnersData);
        }

        // GET: RunnersDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnersData runnersData = db.RunnersDatas.Find(id);
            if (runnersData == null)
            {
                return HttpNotFound();
            }
            return View(runnersData);
        }

        // POST: RunnersDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,StartingTime,FinishTime")] RunnersData runnersData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runnersData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(runnersData);
        }

        // GET: RunnersDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunnersData runnersData = db.RunnersDatas.Find(id);
            if (runnersData == null)
            {
                return HttpNotFound();
            }
            return View(runnersData);
        }

        // POST: RunnersDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RunnersData runnersData = db.RunnersDatas.Find(id);
            db.RunnersDatas.Remove(runnersData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
