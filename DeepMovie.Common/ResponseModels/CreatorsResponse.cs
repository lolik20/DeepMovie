using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class CreatorsResponse
    {
        public string Title { get; set; }
        public string ID { get; set; }
        public IEnumerable<FilmMemberResponse> Data { get; set; }
       
    }
}
