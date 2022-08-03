using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class DonationStage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateTo { get; set; }
        public Film Film { get; set; }
    }
}
