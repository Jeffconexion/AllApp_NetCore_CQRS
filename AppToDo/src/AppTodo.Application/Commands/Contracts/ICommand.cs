using Flunt.Validations;

namespace AppTodo.Application.Commands.Contracts
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 07/04/2022
  /// 
  /// Flunt: version 1.4
  /// All commands I force to hava a contract with ICommand.
  /// Where I validate values.
  /// </summary>
  public interface ICommand : IValidatable
  {

  }
}
