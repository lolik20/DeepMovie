using DeepMovie.Common.Entities;
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

namespace DeepMovie.BL.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly ApplicationContext _context;
        public RegisterHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email || x.Login == request.Login);
            if (user != null)
            {
                return new RegisterResponse
                {
                    IsSuccessful = false
                };
            }
            var newUser = new User
            {
                Role = Role.User,
                Email = request.Email,
                Login = request.Login,
                PasswordHash = Argon2.Hash(request.Password, "test"),
            };
            var userProfile = new UserProfile
            {
                User = newUser
            };
            _context.Users.Add(newUser);
            _context.UserProfile.Add(userProfile);
            _context.SaveChanges();
            var result = new RegisterResponse
            {
                Token = new AuthOptions().GetToken(newUser),
                IsSuccessful = true
            };
            return result;
        }
    }
}
