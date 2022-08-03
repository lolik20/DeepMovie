using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class CredentialsRequest : IRequest<CredentialsResponse>
    {
        public string Token { get; set; }
    }
}
