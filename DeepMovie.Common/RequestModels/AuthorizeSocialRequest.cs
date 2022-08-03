using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class AuthorizeSocialRequest : IRequest<AuthorizeSocialResponse>
    {
        public string Social { get; set; }
        public dynamic Params { get; set; }
    }
}
