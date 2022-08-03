using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string FIO =>$"{Surname} {Name}";
        public string URL { get; set; }
        public List<FilmMember> FilmMembers { get; set; }
        [ForeignKey("Photo")]
        public int? PhotoID { get; set; }
        public Content Photo { get; set; }
    }
}
