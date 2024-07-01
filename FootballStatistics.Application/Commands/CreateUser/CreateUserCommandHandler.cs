using FootballStatistics.Core.Entities;
using FootballStatistics.Core.Repositories;
using MediatR;

namespace FootballStatistics.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;    
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password);
            await _userRepository.CreateUserAsync(user);

            return user.Id;
        }
    }
}
