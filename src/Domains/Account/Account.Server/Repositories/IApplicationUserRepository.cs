namespace Account.Server.Repositories;

public interface IApplicationUserRepository
{
    Task<IdentityResult> RegisterUser(UserForRegisterViewModel userForRegister);
    Task<IdentityResult> RegisterUserWithRoles(UserForRegisterViewModel userForRegister, IEnumerable<string> roles);
    Task<bool> ValidateUser(UserForLoginViewModel userForLogin);
    Task<AppUser> GetUserByUserName(string userName);
    Task<AppUser> GetUserByEmail(string email);
    Task<IEnumerable<string>> GetUserRoles(AppUser user);
    Task UpdateUser(AppUser user);
    Task ForgotPassword(string email, string resetPasswordUrl);
    Task ResetPassword(ResetPasswordViewModel resetPasswordViewModel);
}
