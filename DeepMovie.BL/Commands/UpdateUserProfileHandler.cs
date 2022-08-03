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

namespace DeepMovie.BL.Commands
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileRequest, UpdateUserProfileResponse>
    {
        private readonly ApplicationContext _context;
        public UpdateUserProfileHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<UpdateUserProfileResponse> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            int id = new AuthOptions().GetIdFromToken(request.Token);
            var profile = _context.UserProfile.FirstOrDefault(x => x.UserID == id);
            if (profile == null)
            {
                return new UpdateUserProfileResponse
                {
                    IsSuccess = false
                };
            }

            profile.ID = request.ID;
            profile.Apartment = request.Apartment;
            profile.City = request.City;
            profile.Country = request.Country;
            profile.FIO = request.FIO;
            profile.House = request.House;
            profile.Phone = request.Phone;
            profile.Street = request.Street;

            _context.SaveChanges();
            return new UpdateUserProfileResponse
            {
                IsSuccess = true
            };
        }
    }
}
