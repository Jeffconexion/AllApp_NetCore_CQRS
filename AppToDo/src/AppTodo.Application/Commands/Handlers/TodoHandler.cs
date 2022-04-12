using System;
using System.Threading.Tasks;
using AppTodo.Application.Commands.Contracts;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Core.IRepositories;
using Flunt.Notifications;

namespace AppTodo.Application.Commands.Handlers
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 12/04/2022
  ///
  /// Class to execution commands.
  /// </summary>
  public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
  {
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
      _repository = repository;
    }

    public async Task<ICommandResult> Handle(CreateTodoCommand command)
    {
      throw new NotImplementedException();
    }
  }
}
