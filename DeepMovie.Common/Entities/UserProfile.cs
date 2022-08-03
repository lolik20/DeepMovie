
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string? FIO { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartment { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
