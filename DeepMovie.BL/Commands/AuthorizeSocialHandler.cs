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
    public class AuthorizeSocialHandler : IRequestHandler<AuthorizeSocialRequest, AuthorizeSocialResponse>
    {
        private readonly ApplicationContext _context;
        public AuthorizeSocialHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<AuthorizeSocialResponse> Handle(AuthorizeSocialRequest request, CancellationToken cancellationToken)
        {
            string id;
            string login;
            string email;
            var handler = new AuthOptions();

            switch (request.Social)
            {
                case "vk":
                    id = request.Params.id;
                    login = request.Params.first_name;
                    if (id == null)
                    {
                        return new AuthorizeSocialResponse { IsSuccessful = false, Token = null };
                    }
                    var user = _context.Users.FirstOrDefault(x => x.VkID == id);

                    if (user == null)
                    {
                        user = new User() { VkID = id, Role = Role.User, Login = login, PasswordHash = Argon2.Hash(new Random(DateTime.Now.Millisecond).ToString()) };
                        _context.Users.Add(user);
                        _context.SaveChanges();
                    }
                    return new AuthorizeSocialResponse
                    {
                        IsSuccessful = true,
                        Token = handler.GetToken(user)
                    };

                case "google":

                    id = request.Params["id"];
                    login = request.Params["name"];
                    email = request.Params["email"];
                    if (id == null)
                    {
                        return new AuthorizeSocialResponse
                        {
                            IsSuccessful = false,
                            Token = null
                        };
                    }
                    user = _context.Users.FirstOrDefault(x => x.GoogleID == id);
                    if (user == null)
                    {
                        user = new User()
                        {
                            GoogleID = id,
                            Role = Role.User,
                            Login = login,
                            PasswordHash = Argon2.Hash(new Random(DateTime.Now.Millisecond).ToString()),
                            Email = email
                        };
                        _context.Users.Add(user);
                        _context.SaveChanges();
                    }
                    return new AuthorizeSocialResponse
                    {
                        IsSuccessful = true,
                        Token = handler.GetToken(user)
                    };

                case "facebook":
                    id = request.Params["id"];
                    login = request.Params["name"];
                    if (id == null)
                    {
                        return new AuthorizeSocialResponse
                        {
                            IsSuccessful = false,
                            Token = null
                        };
                    }
                    user = _context.Users.FirstOrDefault(x => x.FacebookID == id);
                    if (user == null)
                    {
                        user = new User()
                        {
                            FacebookID = id,
                            Login = login,
                            Role = Role.User,
                            PasswordHash = Argon2.Hash(new Random(DateTime.Now.Millisecond).ToString())
                        };
                        _context.Users.Add(user);
                        _context.SaveChanges();
                    }
                    return new AuthorizeSocialResponse
                    {
                        IsSuccessful = true,
                        Token = handler.GetToken(user)
                    };

            }
            return new AuthorizeSocialResponse
            {
                IsSuccessful = false,
                Token = null
            };

        }
    }
}
