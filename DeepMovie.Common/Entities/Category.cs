using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<FilmCategory> FilmCategories { get; set; }
    }
}
