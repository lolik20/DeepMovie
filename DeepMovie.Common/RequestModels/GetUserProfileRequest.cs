using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class GetUserProfileRequest : IRequest<GetUserProfileResponse>
    {
        public string? Token { get; set; }
    }
}
