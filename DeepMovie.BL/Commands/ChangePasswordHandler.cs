using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using DeepMovie.DAL;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepMovie.BL.Commands
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _argonKey;

        public ChangePasswordHandler(ApplicationContext context)
        {
            _context = context;
            _argonKey = _configuration.GetValue<string>("argonKey");
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            int id = new AuthOptions().GetIdFromToken(request.Token);
            var dbUser = _context.Users.FirstOrDefault(x => x.Id == id);
            bool IsPasswordCorrect = Argon2.Verify(dbUser.PasswordHash, request.OldPassword, _argonKey);
            if (IsPasswordCorrect)
            {
                dbUser.PasswordHash = Argon2.Hash(request.NewPassword, _argonKey);
                return new ChangePasswordResponse
                {
                    IsSuccessful = true
                };
            }
            return new ChangePasswordResponse
            {
                IsSuccessful = false
            };
        }
    }
}
