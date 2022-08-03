using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Link
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public Film Film { get; set; }
    }
}
