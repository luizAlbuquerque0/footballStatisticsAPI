namespace FootballStatistics.Core.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
    }
}
