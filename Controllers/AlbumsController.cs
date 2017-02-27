using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumsController : Controller
    {

        private Manager m = new Manager();

        [Authorize(Roles = "Assistant, Clerk, Coordinator, Director,Executive, Staff")]
        // GET: Albums
        public ActionResult Index()
        {

            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5

        [Authorize(Roles = "Assistant, Clerk, Coordinator, Director,Executive, Staff")]
        public ActionResult Details(int? id)
        {
            var o = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());

            

            if (o == null)
            {
                System.Diagnostics.Debug.WriteLine("ALBUM with ID was not found" + id.GetValueOrDefault());
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }


        [Authorize(Roles = "Clerk")]
        public ActionResult AddTrack(int? id)
        {
            var a = m.AlbumGetByIdWithDetail(id.GetValueOrDefault());
            var o = new TrackAddForm();

            List<int> temp = new List<int>();
            temp.Add(id.GetValueOrDefault());

            o.AlbumName = a.Name;
            o.AlbumId = a.Id;
            o.GenreList = new SelectList(items: m.GenreGetAll(), dataValueField: "Name", dataTextField: "Name");


            return View(o);

        }

        [HttpPost]
        public ActionResult AddTrack(TrackAdd newItem)
        {

            newItem.Clerk = User.Identity.Name;


            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("INVALID OBJECT");
                System.Diagnostics.Debug.WriteLine(newItem.AlbumId);
                System.Diagnostics.Debug.WriteLine(newItem.Clerk);
                System.Diagnostics.Debug.WriteLine(newItem.ClipUpload);
                System.Diagnostics.Debug.WriteLine(newItem.Genre);
                System.Diagnostics.Debug.WriteLine(newItem.Name);
                System.Diagnostics.Debug.WriteLine(newItem.Composers);
               // System.Diagnostics.Debug.WriteLine(newItem.AlbumIds);






                return View(newItem);

            }

            System.Diagnostics.Debug.WriteLine("OBJECT IS VALID");
            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }

            else {

                return RedirectToAction("details", new { id = newItem.AlbumId });
            }

        }





        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
