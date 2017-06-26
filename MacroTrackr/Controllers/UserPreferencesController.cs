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
using Nutritionix;


namespace MacroTrackr.Controllers
{

    [Authorize]
    public class UserPreferencesController : Controller
    {

        

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserPreferences
        public ActionResult Index()
        {
            //var userPreferences = db.UserPreferences.Include(u => u.Macro);
            //return View(userPreferences.ToList());
            string userID = User.Identity.GetUserId();
            return View(db.UserPreferences.Include(u => u.Macro).Where(p => p.UserID == userID).ToList());
        }

        /*GET: UserPreferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPreference userPreference = db.UserPreferences.Find(id);
            if (userPreference == null)
            {
                return HttpNotFound();
            }
            return View(userPreference);
        }*/

        // GET: UserPreferences/Create
        public ActionResult Create()
        {
            // Only allows user to select MacroNutrients they haven't already selected.
            string userId = User.Identity.GetUserId();

            var userPreferences = db.UserPreferences.Include(u => u.Macro).Where( p => p.UserID == userId).Select(p => p.MacroNutrientID);

           

            ViewBag.MacroNutrientID = new SelectList(db.MacroNutrients.Where( m => !userPreferences.Contains(m.MacroNutrientID)), "MacroNutrientID", "Name");
            return View();
        }

        // POST: UserPreferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserPreferenceID,MacroNutrientID,Minimum,Maximum")] UserPreference userPreference)
        {

            userPreference.UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.UserPreferences.Add(userPreference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MacroNutrientID = new SelectList(db.MacroNutrients, "MacroNutrientID", "Name", userPreference.MacroNutrientID);
            return View(userPreference);
        }

        // GET: UserPreferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string userID = User.Identity.GetUserId();
            UserPreference userPreference = db.UserPreferences.Where(p => p.UserID == userID && p.UserPreferenceID == id).FirstOrDefault();
            if (userPreference == null)
            {
                return HttpNotFound();
            }
            ViewBag.MacroNutrientID = new SelectList(db.MacroNutrients, "MacroNutrientID", "Name", userPreference.MacroNutrientID);
            return View(userPreference);
        }

        // POST: UserPreferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserPreferenceID,MacroNutrientID,Minimum,Maximum")] UserPreference userPreference)
        {

            string userID = User.Identity.GetUserId();
            UserPreference originalUP = db.UserPreferences.Where(p => p.UserID == userID && p.UserPreferenceID == userPreference.UserPreferenceID).FirstOrDefault();
            
                        if (originalUP == null)
                            {
                                return HttpNotFound();
                            }

            //Move over all the properties that need to be set.
            
            originalUP.Minimum = userPreference.Minimum;
            originalUP.Maximum = userPreference.Maximum;


            if (ModelState.IsValid)
            {
                db.Entry(originalUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MacroNutrientID = new SelectList(db.MacroNutrients, "MacroNutrientID", "Name", userPreference.MacroNutrientID);
            return View(userPreference);
        }

        // GET: UserPreferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            string userID = User.Identity.GetUserId();
            UserPreference userPreference = db.UserPreferences.Where(p => p.UserID == userID && p.UserPreferenceID == id).FirstOrDefault();

            if (userPreference == null)
            {
                return HttpNotFound();
            }
            return View(userPreference);
        }

        // POST: UserPreferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string userID = User.Identity.GetUserId();
            UserPreference userPreference = db.UserPreferences.Where(p => p.UserID == userID && p.UserPreferenceID == id).FirstOrDefault();
            db.UserPreferences.Remove(userPreference);
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
