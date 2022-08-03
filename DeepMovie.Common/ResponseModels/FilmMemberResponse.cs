using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class FilmMemberResponse
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Role { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
