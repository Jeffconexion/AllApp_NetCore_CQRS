using System.Threading.Tasks;
using AppTodo.Api.Controllers;
using AppTodo.Api.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppTodo.Api.V1.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/Autenticacao")]
  public class AuthController : MainController
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _usermanager;

    public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> usermanager)
    {
      _signInManager = signInManager;
      _usermanager = usermanager;
    }

    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = new IdentityUser
      {
        UserName = registerUser.Email,
        Email = registerUser.Email,
        EmailConfirmed = true
      };

      var result = await _usermanager.CreateAsync(user, registerUser.Password);

      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(user, false);
        return Ok(registerUser);
      }

      return new BadRequestObjectResult(registerUser);
    }

    [HttpPost("entrar")]
    public async Task<ActionResult> Login(LoginUserviewModel loginUser)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);


      var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

      if (result.Succeeded)
      {
        return Ok(loginUser);

      }

      if (result.IsLockedOut)
      {
         ModelState.AddModelError("Usuário Bloqueado","Usuário temporariamente bloqueado por tentativas inválidas");
        return new BadRequestObjectResult(loginUser);
      }

      ModelState.AddModelError("Dados Incorretos", "Usuário ou senha incorretas?");
      return new BadRequestObjectResult(loginUser);
    }

  }
}
