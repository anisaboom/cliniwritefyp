using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FYP2.Models;
using PagedList;

namespace FYP2.Controllers
{
    public class ClientsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Clients
        [Authorize]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var client = from c in db.Clients
                         select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                client = client.Where(s => s.lastname.Contains(searchString)
                                       || s.firstname.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    client = client.OrderByDescending(c => c.lastname);
                    break;
                case "Date":
                    client = client.OrderBy(c => c.dateofbirth);
                    break;
                case "date_desc":
                    client = client.OrderByDescending(c => c.dateofbirth);
                    break;
                default:
                    client = client.OrderBy(c => c.lastname);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(client.ToPagedList(pageNumber, pageSize));
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,dateofbirth,gender,phonenumber,emailaddress,nationality,placeofbirth,addressline1,addressline2,postcode,nhsnumber")] Client client)
        {
            var genderList = new SelectList(new[] { "Male", "Female" });
            ViewBag.GenderList = genderList;
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,dateofbirth,gender,phonenumber,emailaddress,nationality,placeofbirth,addressline1,addressline2,postcode,nhsnumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
        public ActionResult LoadGender()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Male", Value = "1" });
            li.Add(new SelectListItem { Text = "Female", Value = "2" });

            ViewData["Gender"] = li;
            return View();
        }



    }
}
