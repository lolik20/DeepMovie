using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
   public class LoginRequest:IRequest<LoginResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
