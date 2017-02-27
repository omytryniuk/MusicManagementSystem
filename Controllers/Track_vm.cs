using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class TrackAdd
    {

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [StringLength(200)]
        public string Clerk { get; set; }

        [Required]
        public HttpPostedFileBase ClipUpload { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }
        

    }


    public class TrackBase
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        [Display(Name = "Composer names, separated by commas")]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [Required, StringLength(200)]
        public string Clerk { get; set; }

        [Display(Name = "Sample clip")]
        public string ClipUrl {
            get {
                return $"/clip/{Id}";
            }
        }


    }

    public class TrackAddForm
    {

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        [Required, StringLength(200)]
        public string Clerk { get; set; }
        public SelectList GenreList { get; set; }

        [Required]
        [Display(Name = "Track Clip")]
        [DataType(DataType.Upload)]
        public string ClipUpload { get; set; }

        public string AlbumName { get; set; }
        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

    }

    public class TrackWithDetail : TrackBase
    {

    }

    public class TrackClip {

        public int Id { get; set; }
        public string ClipContentType { get; set; }

        public byte[] Clip { get; set; }
    }


}