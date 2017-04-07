using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYP2.Models;
using FYP2.ViewModels;

namespace FYP2.Controllers
{
    public class Clients1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: Clients1
        public ActionResult Index(int? id)
        {
            var viewModel = new ClientViewModel();
            viewModel.Clients = db.Clients
                .Include(r => r.Referrals)
                .Include(r => r.Referrals.Select(c => c.Client))
                .OrderBy(c => c.dateofbirth);




            if (id != null)
            {
                ViewBag.id = id.Value;
                viewModel.Sessions = viewModel.Clients.Where(
                    c => c.id == id.Value).Single().Sessions;
            }



            return View(viewModel);
        }
    }
}


// GET: Clients1/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Client client = db.Clients.Find(id);
//            if (client == null)
//            {
//                return HttpNotFound();
//            }
//            return View(client);
//        }

//        // GET: Clients1/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Clients1/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "id,firstname,lastname,dateofbirth,gender,phonenumber,emailaddress,nationality,placeofbirth,addressline1,addressline2,postcode,nhsnumber")] Client client)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Clients.Add(client);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(client);
//        }

//        // GET: Clients1/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Client client = db.Clients.Find(id);
//            if (client == null)
//            {
//                return HttpNotFound();
//            }
//            return View(client);
//        }

//        // POST: Clients1/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "id,firstname,lastname,dateofbirth,gender,phonenumber,emailaddress,nationality,placeofbirth,addressline1,addressline2,postcode,nhsnumber")] Client client)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(client).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(client);
//        }

//        // GET: Clients1/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Client client = db.Clients.Find(id);
//            if (client == null)
//            {
//                return HttpNotFound();
//            }
//            return View(client);
//        }

//        // POST: Clients1/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Client client = db.Clients.Find(id);
//            db.Clients.Remove(client);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
