namespace UniversityHostel.SharedClient.AuthServices;

public interface IRefreshTokenService
{
    Task<string> TryRefreshToken(string refreshTokenUrl);
}
