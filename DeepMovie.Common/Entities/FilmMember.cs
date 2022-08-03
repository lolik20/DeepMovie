using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class FilmMember
    {
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public MemberRole MemberRole { get; set; }
        public string? Description { get; set; }
    }
}
