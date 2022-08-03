using DeepMovie.Common.Entities;
using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class GetPortalRequest : IRequest<IEnumerable<ContentResponse>>
    {
        public ContentType ContentType { get; set; }
        public int FilmID { get; set; }
    }
}
