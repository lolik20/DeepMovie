using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Review
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int ImageID { get; set; }
        public Content Image { get; set; }
    }
}
