using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class CredentialsResponse
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
