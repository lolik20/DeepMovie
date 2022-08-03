using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class GetFilmsRequest:IRequest<IEnumerable<GetFilmsResponse>>
    {
    }
}
