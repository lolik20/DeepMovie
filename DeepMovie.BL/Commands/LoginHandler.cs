using DeepMovie.BL;
using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using DeepMovie.DAL;
using Isopoh.Cryptography.Argon2;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identy.BL.Commands
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ApplicationContext _context;
        public LoginHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var dbUser = _context.Users
                .FirstOrDefault(x => x.Email.Equals(request.Login) ||
                x.Login.Equals(request.Login));
            if (dbUser != null)
            {
                bool IsPasswordCorrect = Argon2.Verify(dbUser.PasswordHash, request.Password, "test");
                if (IsPasswordCorrect)
                {

                    return new LoginResponse
                    {
                        IsSuccessful = true,
                        Token = new AuthOptions().GetToken(dbUser)
                    };
                };
            }
            else
            {
                return new LoginResponse
                {
                    IsSuccessful = false
                };
            }

            return new LoginResponse
            {
                IsSuccessful = false
            };
        }
    }
}
