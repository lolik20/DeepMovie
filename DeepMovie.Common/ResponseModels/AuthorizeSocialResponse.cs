using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class AuthorizeSocialResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Token { get; set; }
    }
}
