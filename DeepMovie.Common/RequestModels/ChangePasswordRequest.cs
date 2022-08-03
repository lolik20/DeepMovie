using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class ChangePasswordRequest :IRequest< ChangePasswordResponse>
    {
        public string? Token { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
