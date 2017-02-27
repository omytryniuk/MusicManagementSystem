using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    
    public class ClipController : Controller
    {
        private Manager m = new Manager();
        
        // GET: Clip
        public ActionResult Index()
        {
            return View("index","home");
        }



        // GET: Clip/Details/5
        [Route("clip/{id}")]
        public ActionResult Details(int? id)
        {
            System.Diagnostics.Debug.WriteLine("CALLING clip details");

            var o = m.TrackClipGetById(id.GetValueOrDefault());

            if (o.Clip == null) {
                System.Diagnostics.Debug.WriteLine("CLIP is null");
            }

            if (o.ClipContentType == null) {
                System.Diagnostics.Debug.WriteLine("CONTENTYPE IS NULL");

            }



            if (o == null || o.ClipContentType == null)
            {
                return HttpNotFound();
            }
            else {

                return File(o.Clip, o.ClipContentType);
            }

            
        }

        // GET: Clip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clip/Create
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

        // GET: Clip/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clip/Edit/5
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

        // GET: Clip/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clip/Delete/5
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
