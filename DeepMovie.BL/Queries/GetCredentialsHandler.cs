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
    public class GetCredentialsHandler : IRequestHandler<CredentialsRequest, CredentialsResponse>
    {
        private readonly ApplicationContext _context;
        public GetCredentialsHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<CredentialsResponse> Handle(CredentialsRequest request, CancellationToken cancellationToken)
        {
            var handler = new AuthOptions();
            int id = handler.GetIdFromToken(request.Token);
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return new CredentialsResponse
            {
                Email = user.Email,
                ID = user.Id,
                Login = user.Login
            };
        }
    }
}
