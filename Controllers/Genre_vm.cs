using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment8.Controllers
{
    public class GenreBase
    {
       public int Id { get; set; }

       [Required, StringLength(100)]
       public string Name { get; set; }
    }
}