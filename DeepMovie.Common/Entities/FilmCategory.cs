using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class FilmCategory
    {
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }


}
