using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppTodo.Api.Controllers;
using AppTodo.Api.Extensions;
using AppTodo.Api.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AppTodo.Api.V1.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/Autenticacao")]
  public class AuthController : MainController
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings; //I can use appsetings

    public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Criar novo Usuário.   
    /// </summary>
    /// <param name="registerUser"></param>
    /// <returns></returns>
    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
    {
      //"email": "teste@gmail.com",
      //"password": "Teste@123",
      //"confirmPassword": "Teste@123"

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = new IdentityUser
      {
        UserName = registerUser.Email,
        Email = registerUser.Email,
        EmailConfirmed = true
      };

      var result = await _userManager.CreateAsync(user, registerUser.Password);

      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(user, false);
        return Ok(GerarJwt());
      }

      ModelState.AddModelError("Usuário já cadastrado", "Já existe um usuário cadastrado com email ou senha na base de dados.");
      return new BadRequestObjectResult(ModelState);
    }

    /// <summary>
    /// Entrar com usuário criado.
    /// </summary>
    /// <param name="loginUser"></param>
    /// <returns></returns>
    [HttpPost("entrar")]
    public async Task<ActionResult> Login(LoginUserviewModel loginUser)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);


      var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

      if (result.Succeeded)
      {
        return Ok(GerarJwt());

      }

      if (result.IsLockedOut)
      {
        ModelState.AddModelError("Usuário Bloqueado", "Usuário temporariamente bloqueado por tentativas inválidas");
        return new BadRequestObjectResult(loginUser);
      }

      ModelState.AddModelError("Dados Incorretos", "Usuário ou senha incorretas?");
      return new BadRequestObjectResult(loginUser);
    }

    //Continuar nos 17 minutos.

    /// <summary>
    /// Geração de token para entrar e registrar.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    private /*async Task<LoginResponseViewModel>*/ string GerarJwt(/*string email*/)
    {
      //var user = await _userManager.FindByEmailAsync(email);
      //var claims = await _userManager.GetClaimsAsync(user);
      //var userRoles = await _userManager.GetRolesAsync(user);

      //claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
      //claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
      //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
      //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
      //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
      //foreach (var userRole in userRoles)
      //{
      //  claims.Add(new Claim("role", userRole));
      //}

      //var identityClaims = new ClaimsIdentity();
      //identityClaims.AddClaims(claims);


      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
      {
        Issuer = _appSettings.Issuer,
        Audience = _appSettings.ValidIn,
        //Subject = identityClaims,
        Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHoures),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      });

      var encodedToken = tokenHandler.WriteToken(token);
      return encodedToken;
      //var response = new LoginResponseViewModel
      //{
      //  AccessToken = encodedToken,
      //  ExpiresIn = TimeSpan.FromHours(_appSettings.ExpirationHoures).TotalSeconds,
      //  UserToken = new UserTokenViewModel
      //  {
      //    Id = user.Id,
      //    Email = user.Email,
      //    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
      //  }
      //};

      //return response;
    }

    private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

  }
}
