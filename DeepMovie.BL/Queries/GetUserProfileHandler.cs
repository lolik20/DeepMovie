using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using DeepMovie.DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepMovie.BL.Queries
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, GetUserProfileResponse>
    {
        private readonly ApplicationContext _context;
        public GetUserProfileHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<GetUserProfileResponse> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
        {
            int id = new AuthOptions().GetIdFromToken(request.Token);
            var userProfile = _context.UserProfile.FirstOrDefault(x => x.UserID==id);
            if (userProfile != null)
            {
                return new GetUserProfileResponse
                {
                    ID = userProfile.ID,
                    Apartment = userProfile.Apartment,
                    Street = userProfile.Street,
                    City = userProfile.City,
                    Country = userProfile.Country,
                    FIO = userProfile.FIO,
                    House = userProfile.House,
                    Phone = userProfile.Phone
                };
            }
            else
            {
                return null;
            }
        }
    }
}
