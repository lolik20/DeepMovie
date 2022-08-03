using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
   public class RegisterResponse
    {
        public string Token { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
