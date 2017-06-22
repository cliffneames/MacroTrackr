using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MacroTrackr.Models;
using Microsoft.AspNet.Identity;

namespace MacroTrackr.Controllers
{
    [Authorize]
    public class FoodItemsController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FoodItems
        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();
            return View(db.FoodItems.Where(p => p.UserID == userID).ToList());
        }

        // GET: FoodItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // GET: FoodItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodItemID,Name,TimeOfMeal,WhenEaten,Carbs,Protein,Fat")] FoodItem foodItem)
        {
            foodItem.UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.FoodItems.Add(foodItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodItem);
        }

        // GET: FoodItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodItem foodItem = db.FoodItems.Find(id);

            string userID = User.Identity.GetUserId();
            FoodItem fooditem = db.FoodItems.Where(p => p.UserID == userID && p.FoodItemID == id).FirstOrDefault();
            
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodItemID,Name,TimeOfMeal,WhenEaten,Carbs,Protein,Fat")] FoodItem foodItem)
        {
            string userID = User.Identity.GetUserId();
            FoodItem fooditem1 = db.FoodItems.Where(p => p.UserID == userID && p.FoodItemID == foodItem.FoodItemID).FirstOrDefault();
            
            if (fooditem1 == null)
            {
                return HttpNotFound();
            }
            
            //Move over all the properties that need to be set.
            fooditem1.Name = foodItem.Name;

            if (ModelState.IsValid)
            {
                db.Entry(fooditem1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodItem);
        }

        // GET: FoodItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userID = User.Identity.GetUserId();
            FoodItem foodItem = db.FoodItems.Where(p => p.UserID == userID && p.FoodItemID == id).FirstOrDefault();
            if (foodItem == null)
            {
                return HttpNotFound();
            }
            return View(foodItem);
        }

        // POST: FoodItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string userID = User.Identity.GetUserId();
            FoodItem foodItem = db.FoodItems.Where(p => p.UserID == userID && p.FoodItemID == id).FirstOrDefault();

            db.FoodItems.Remove(foodItem);
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

        public ActionResult Dailyview()
        {
            string userID = User.Identity.GetUserId();
            return View(db.FoodItems.Where(p => p.UserID == userID && DbFunctions.TruncateTime(p.WhenEaten) == DbFunctions.TruncateTime(DateTime.Now)).ToList());

            
        }
    }
}
