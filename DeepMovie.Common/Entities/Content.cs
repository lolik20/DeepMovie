using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Content
    {
        public int ID { get; set; }
        public string? URL { get; set; }
        public string? Text { get; set; }
        [ForeignKey("Member")]
        public int? MemberID { get; set; }
        public Member Member { get; set; }
        [ForeignKey("Film")]
        public int? FilmID { get; set; }
        public Film Film { get; set; }
        public ContentType ContentType { get; set; }
    }
}
