using System.Threading.Tasks;
using AppTodo.Application.Commands.Contracts;

namespace AppTodo.Application.Commands.Handlers.Contracts
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 12/04/2022
  /// 
  /// Interface IHandler.
  /// only propor is a group of object
  /// </summary>
  public interface IHandler<T> where T : ICommand
  {
    /// <summary>
    /// Return result of the execution handler.
    /// </summary>
    /// <param name="command">object type of ICommand</param>
    /// <returns></returns>
    Task<ICommandResult> Handle(T command);

  }
}
