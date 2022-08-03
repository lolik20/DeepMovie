using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string? VkID { get; set; }
        public string? FacebookID { get; set; }
        public string? GoogleID { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
