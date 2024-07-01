using FootballStatistics.Core.Entities;
using FootballStatistics.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootballStatistics.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FootballStatisticsDbContext _dbContext;
        public UserRepository(FootballStatisticsDbContext dbContext)
        {
                _dbContext = dbContext;
        }
        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email || u.Password == password);
        }
    }
}
