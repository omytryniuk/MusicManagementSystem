using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{

    public class ArtistsController : Controller
    {

        private Manager m = new Manager();


        [Authorize(Roles = "Assistant, Clerk, Coordinator, Director,Executive, Staff")]
        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        [Authorize(Roles = "Assistant, Clerk, Coordinator, Director,Executive, Staff")]
        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }


        [Authorize(Roles = "Executive")]
        // GET: Artists/Create
        public ActionResult Create()
        {
            var a = new ArtistAddForm();
            a.GenreList = new SelectList
                    (items: m.GenreGetAll(),
                    dataValueField: "Name",
                    dataTextField: "Name");
            return View(a);
        }

        // POST: Artists/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAdd newItem)
        {

            if (!ModelState.IsValid) {
                return View(newItem);
            }

            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }

            else {
                return RedirectToAction("details", new { id = addedItem.Id });
            }

        }

        [Authorize(Roles = "Coordinator")]
        public ActionResult AddAlbum(int? id)
        {
            var a = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (a == null)
            {
                return HttpNotFound();
            }

            else {
                var o = new AlbumAddForm();
           //     o.ArtistId = id.GetValueOrDefault();
              //  List<int> temp = new List<int>();
                //temp.Add(id.GetValueOrDefault());
                o.ArtistName = a.Name;
                o.ArtistId = id.GetValueOrDefault();
                o.GenreList = new SelectList(items: m.GenreGetAll(), dataValueField: "Name", dataTextField: "Name");
                return View(o);
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAdd newItem)
        {

          //  newItem.Coordinator = User.Identity.Name;
            
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("INVALID OBJECT");
                System.Diagnostics.Debug.WriteLine("BirthName" + newItem.ArtistId);
                System.Diagnostics.Debug.WriteLine("BirthName" + newItem.Description);
                //  System.Diagnostics.Debug.WriteLine("Executive" + newItem.Executive);
                System.Diagnostics.Debug.WriteLine("Genre" + newItem.Genre);
                System.Diagnostics.Debug.WriteLine("NAME" + newItem.Name);
                System.Diagnostics.Debug.WriteLine("URL" + newItem.Name);
                System.Diagnostics.Debug.WriteLine("PROFILE" + newItem.ReleaseDate);
                System.Diagnostics.Debug.WriteLine("PROFILE" + newItem.UrlAlbum);


                return View(newItem);

            }

            System.Diagnostics.Debug.WriteLine("ARTIST ID IS" + newItem.ArtistId);
            var addedItem = m.AlbumAdd(newItem);
          //  System.Diagnostics.Debug.WriteLine("There are songs: " + addedItem.Tracks.Count());


            if (addedItem == null)
            {
                return View(newItem);
            }

            else {

                return RedirectToAction("details", "albums", new { id = addedItem.Id });
    
            }

        }

        public ActionResult AddMediaItem(int? id)
        {
            // Attempt to get the matching object
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form
                var form = new MediaItemAddForm();
                // Configure its property values
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}<br>genre is {o.Genre}";

                // Pass the object to the view
                return View(form);
            }
        }

        [HttpPost]
        public ActionResult AddMediaItem(int? id, MediaItemAdd newItem)
        {

            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId) {
                return View(newItem);

            }

            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);

            }
            else {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }

            // Attempt to get the matching object
            var o = m.ArtistGetByIdWithDetail(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form
                var form = new MediaItemAddForm();
                // Configure its property values
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}";

                // Pass the object to the view
                return View(form);
            }
        }

        public ActionResult DetailsWithMediaItemInfo(int? id)
        {
            // Attempt to get the matching object
            var o = m.ArtistGetByIdWithMediaInfo(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }


        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artists/Edit/5
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

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artists/Delete/5
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
