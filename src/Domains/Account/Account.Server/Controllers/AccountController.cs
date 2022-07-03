namespace Account.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<UserForRegisterViewModel> _userForRegisterValidator;
    private readonly IValidator<UserForLoginViewModel> _userForLoginValidator;

    public AccountController(ITokenService tokenService, IApplicationUserRepository applicationUserRepository, UserManager<AppUser> userManager,
        IValidator<UserForRegisterViewModel> userForRegisterValidator, IValidator<UserForLoginViewModel> userForLoginValidator)
    {
        _tokenService = tokenService;
        _applicationUserRepository = applicationUserRepository;
        _userManager = userManager;
        _userForRegisterValidator = userForRegisterValidator;
        _userForLoginValidator = userForLoginValidator;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(UserForRegisterViewModel userForRegister)
    {
        if (userForRegister == null)
            return BadRequest("User is null");

        var validationResult = await _userForRegisterValidator.ValidateAsync(userForRegister);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        IdentityResult result = await _applicationUserRepository.RegisterUserWithRoles(userForRegister, new[] { "User" });
        if (!result.Succeeded)
        {
            IEnumerable<string> errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { errors });
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginViewModel userLogin)
    {
        var validationResult = await _userForLoginValidator.ValidateAsync(userLogin);
        if (!validationResult.IsValid)
        {
            string text = string.Join("-", validationResult.Errors.Select(e => e.ErrorMessage));
            return BadRequest(new AuthResponseViewModel { ErrorMessage = text });
        }

        if (!await _applicationUserRepository.ValidateUser(userLogin))
            return Unauthorized(new AuthResponseViewModel { ErrorMessage = "Invalid UserName Or Password" });

        AppUser user = await _applicationUserRepository.GetUserByUserName(userLogin.UserName);

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _applicationUserRepository.UpdateUser(user);

        AuthResponseViewModel authResponse = new AuthResponseViewModel
        {
            IsAuthSuccessful = true,
            Token = await _tokenService.CreateToken(user, await _applicationUserRepository.GetUserRoles(user)),
            RefreshToken = user.RefreshToken
        };
        return Ok(authResponse);
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(RefreshTokenViewModel refreshTokenViewModel)
    {
        if (refreshTokenViewModel == null || string.IsNullOrEmpty(refreshTokenViewModel.Token) || string.IsNullOrEmpty(refreshTokenViewModel.RefreshToken))
            return BadRequest(new AuthResponseViewModel { ErrorMessage = "Invalid Client Request" });

        ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(refreshTokenViewModel.Token);
        Console.WriteLine(principal.Identity.Name);
        Console.WriteLine(principal.FindFirst(ClaimTypes.Name).Value);
        AppUser user = await _applicationUserRepository.GetUserByUserName(principal.FindFirst(ClaimTypes.Name).Value);

        if (user is null || user.RefreshToken != refreshTokenViewModel.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return BadRequest(new AuthResponseViewModel { ErrorMessage = "Invalid Client Request" });
        }

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        await _applicationUserRepository.UpdateUser(user);

        AuthResponseViewModel authResponse = new AuthResponseViewModel
        {
            IsAuthSuccessful = true,
            Token = await _tokenService.CreateToken(user, await _applicationUserRepository.GetUserRoles(user)),
            RefreshToken = user.RefreshToken
        };
        return Ok(authResponse);
    }

    [HttpPost("forgotPassword")]
    public async Task<IActionResult> FogotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
    {
        string resetPasswordUrl = $"https://{Request.Host.Value.Trim('/')}/reset-password";
        await _applicationUserRepository.ForgotPassword(forgotPasswordViewModel.Email, resetPasswordUrl);

        return Ok();
    }

    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
    {
        await _applicationUserRepository.ResetPassword(resetPasswordViewModel);

        return Ok();
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
    {
        AppUser user = await _userManager.GetUserAsync(HttpContext.User);
        //var userId = (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier)?.Value;

        await _applicationUserRepository.ChangePassword(changePasswordViewModel, user);

        return Ok();
    }
}