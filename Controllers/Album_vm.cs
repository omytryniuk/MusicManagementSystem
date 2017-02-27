using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumAdd
    {
        public AlbumAdd()
        {
            ReleaseDate = DateTime.Now;
           // Artists = new List<Artist>();
          //  Tracks = new List<Track>();
        }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        [Display(Name = "URL to album image (cover art)")]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }

        // User name who looks after the album
       

        [Required, StringLength(10000)]
        [Display(Name = "Album description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int ArtistId { get; set; }

       [Display(Name = "Number of tracks")]
       public int TracksCount { get; set; }



    }

    public class AlbumBase : AlbumAdd {
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Coordinator { get; set; }
    }

    public class AlbumAddForm : AlbumAdd
    {
           
    public string ArtistName { get; set; }

    public SelectList GenreList { get; set; }

    }

    public class AlbumWithDetail : AlbumBase
    {

        public AlbumWithDetail()
        {
            Tracks = new List<TrackBase>();
        }

        [Display(Name = "Tracks with this Album")]
        public IEnumerable<TrackBase> Tracks { get; set; }


    }


}






