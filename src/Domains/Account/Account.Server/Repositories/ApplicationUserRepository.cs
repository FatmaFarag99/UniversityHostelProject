namespace Account.Server.Repositories;

using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using UniversityHostel.Shared.Services;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;

    public ApplicationUserRepository(UserManager<AppUser> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
    }

    public async Task<bool> ValidateUser(UserForLoginViewModel userForLogin)
    {
        AppUser user = await _userManager.FindByNameAsync(userForLogin.UserName);

        return (user != null && await _userManager.CheckPasswordAsync(user, userForLogin.Password));
    }
    public async Task<AppUser> GetUserByUserName(string userName) => await _userManager.FindByNameAsync(userName);
    public async Task<AppUser> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);
    public async Task UpdateUser(AppUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            string error = string.Join("-", result.Errors.Select(e => e.Description));
            throw new Exception(error);
        }
    }
    public async Task<IdentityResult> RegisterUser(UserForRegisterViewModel userForRegister)
    {
        string userFullName = $"{userForRegister.FirstName} {userForRegister.LastName}";

        AppUser user = new AppUser
        {
            FullName = userFullName,
            UserName = userForRegister.UserName,
            PhoneNumber = userForRegister.PhoneNumber,
            Email = userForRegister.Email,
        };
        return await _userManager.CreateAsync(user, userForRegister.Password);
    }
    public async Task<IdentityResult> RegisterUserWithRoles(UserForRegisterViewModel userForRegister, IEnumerable<string> roles)
    {
        string userFullName = $"{userForRegister.FirstName} {userForRegister.LastName}";

        AppUser user = new AppUser
        {
            FullName = userFullName,
            UserName = userForRegister.UserName,
            PhoneNumber = userForRegister.PhoneNumber,
            Email = userForRegister.Email,
        };
        IdentityResult result = await _userManager.CreateAsync(user, userForRegister.Password);
        if (!result.Succeeded)
            return result;

        return await _userManager.AddToRolesAsync(user, roles);
    }

    public async Task<IEnumerable<string>> GetUserRoles(AppUser user) => await _userManager.GetRolesAsync(user);

    public async Task ForgotPassword(string email, string resetPasswordUrl)
    {
        AppUser user = await GetUserByEmail(email);
        if (user == default)
        {
            throw new Exception("Email isn't registered.");
        }

        string code = await _userManager.GeneratePasswordResetTokenAsync(user);

        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        resetPasswordUrl += $"?code={code}";

        var html = $@"
<!doctype html>
<html lang=""en-US"">

<head>
    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"" />
    <title>Reset Password Email Template</title>
    <meta name=""description"" content=""Reset Password Email Template."">
    <style type=""text/css"">
        a:hover {{text-decoration: underline !important;}}
    </style>
</head>

<body marginheight=""0"" topmargin=""0"" marginwidth=""0"" style=""margin: 0px; background-color: #f2f3f8;"" leftmargin=""0"">
    <!--100% body table-->
    <table cellspacing=""0"" border=""0"" cellpadding=""0"" width=""100%"" bgcolor=""#f2f3f8""
        style=""@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;"">
        <tr>
            <td>
                <table style=""background-color: #f2f3f8; max-width:670px;  margin:0 auto;"" width=""100%"" border=""0""
                    align=""center"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=""text-align:center;"">
                        </td>
                    </tr>
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width=""95%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""
                                style=""max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);"">
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style=""padding:0 35px;"">
                                        <h1 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;"">You have
                                            requested to reset your password</h1>
                                        <span
                                            style=""display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;""></span>
                                        <p style=""color:#455056; font-size:15px;line-height:24px; margin:0;"">
                                            We cannot simply send you your old password. A unique link to reset your
                                            password has been generated for you. To reset your password, click the
                                            following link and follow the instructions.
                                        </p>
                                        <a href=""{HtmlEncoder.Default.Encode(resetPasswordUrl)}""
                                            style=""background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;"">Reset
                                            Password</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--/100% body table-->
</body>

</html>";

        await _emailService.SendEmailAsync(email, "Reset Password", html);
            //$"Please reset your password by <a href='{HtmlEncoder.Default.Encode(resetPasswordUrl)}'>clicking here</a>.");
    }

    public async Task ResetPassword(ResetPasswordViewModel model)
    {
        AppUser user = await GetUserByEmail(model.Email);
        if (user == default)
        {
            throw new Exception("Email isn't registered.");
        }

        var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));

        var result = await _userManager.ResetPasswordAsync(user, code, model.Password);
        if (!result.Succeeded)
        {
            string error = string.Join("-", result.Errors.Select(e => e.Description));
            throw new Exception(error);
        }
    }

    public async Task ChangePassword(ChangePasswordViewModel changePasswordViewModel, AppUser user)
    {
        
        //AppUser user = await _userManager.FindByIdAsync(userId);
        
        var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
        if (!result.Succeeded)
        {
            string error = string.Join("-", result.Errors.Select(e => e.Description));
            throw new Exception(error);
        }
    }
}