using FootballStatistics.Core.Entities;
using FootballStatistics.Core.Repositories;
using FootballStatistics.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authSerice)
        {
            _userRepository = userRepository;
            _authService = authSerice;
        }
        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetUserByEmailAndPassword(request.Email, passwordHash);

            return user;
        }
    }
}
