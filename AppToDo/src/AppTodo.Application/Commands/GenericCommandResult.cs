using AppTodo.Application.Commands.Contracts;

namespace AppTodo.Application.Commands
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 07/04/2022
  /// 
  /// Generic Class to return a message to use.
  /// </summary>
  public class GenericCommandResult : ICommandResult
  {
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public GenericCommandResult()
    {
    }

    public GenericCommandResult(bool success, string message, object data)
    {
      Success = success;
      Message = message;
      Data = data;
    }
  }
}
