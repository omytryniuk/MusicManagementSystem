using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class ArtistAdd
    {
        public ArtistAdd()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
       //     Albums = new List<Album>();
        }

    [Display(Name = "Artist name or stage name")]
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Display(Name = "If applicable, artist's birth name")]
    [StringLength(100)]
    public string BirthName { get; set; }

    [Display(Name = "Birth date, or start date")]
    [DataType(DataType.Date)]
    public DateTime BirthOrStartDate { get; set; }

    [Required, StringLength(200)]
    [Display(Name = "URL to artist photo")]
    public string UrlArtist { get; set; }

    [Required]
    [Display(Name = "Artist's primary genre")]
    public string Genre { get; set; }


    [Required, StringLength(10000)]
    [Display(Name = "Artist profile")]
    [DataType(DataType.MultilineText)]
    public string Profile { get; set; }

    [Display(Name = "Number of albums")]
    public int AlbumsCount { get; set; }

    }

    public class ArtistBase : ArtistAdd {

    [Key]
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Executive { get; set; }
    
    }

    public class ArtistAddForm : ArtistAdd
    {
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }


    }

    public class ArtistWithDetail : ArtistBase
    {
        public ArtistWithDetail()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "Albums with this Artist")]
        public IEnumerable<AlbumBase> Albums { get; set; }

    }




    public class ArtistWithMediaInfo : ArtistBase
    {
        public ArtistWithMediaInfo()
        {
           MediaItems = new List<MediaItemBase>();
        }

        [Display(Name = "Media items with this Artist")]
        public IEnumerable<MediaItemBase> MediaItems { get; set; }

    }


}

