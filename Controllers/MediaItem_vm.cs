using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment8.Controllers
{
    public class MediaItemAddForm
    {
        public int ArtistId { get; set; }

        public string ArtistInfo { get; set; }

        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media item")]
        [DataType(DataType.Upload)]
        public string MediaItemUpload { get; set; }


    }

    public class MediaItemAdd {
        public int ArtistId { get; set; }
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaItemUpload { get; set; }


    }

    public class MediaItemBase {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string StringId { get; set; }
        public string Caption { get; set; }
        public string ContentType { get; set; }

    }

    public class MediaItemContent {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }


    }

}

