using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class ReviewResponse
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ImageURL { get; set; }
    }
}
