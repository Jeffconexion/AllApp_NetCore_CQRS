using System.ComponentModel.DataAnnotations;

namespace AppTodo.Api.ViewModel
{
  public class RegisterUserViewModel
  {
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "O campo {0} é obrigatório.")]
    public string ConfirmPassword { get; set; }
  }

  public class LoginUserviewModel
  {
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Password { get; set; }

  }
}
