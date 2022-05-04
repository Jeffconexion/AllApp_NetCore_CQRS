using System.Threading.Tasks;
using AppTodo.Application.Commands.Contracts;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Core.Entities;
using AppTodo.Core.IRepositories;
using Flunt.Notifications;

namespace AppTodo.Application.Commands.Handlers.CreateTodo
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 04/05/2022
  ///
  /// Class to execution commands.
  /// </summary>
  public class CreateTodoCommandHandler : Notifiable, IHandler<CreateTodoCommand>
  {
    private readonly ITodoRepository _repository;

    public CreateTodoCommandHandler(ITodoRepository repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Execution command Create task.
    /// </summary>
    /// <param name="command">object command.</param>
    /// <returns></returns>
    public async Task<ICommandResult> Handle(CreateTodoCommand command)
    {
      command.Validate();

      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      TodoItem todo = new TodoItem(command.Title, command.User, command.Date);

      await _repository.Create(todo);

      return new GenericCommandResult(true, "Tarefa Salva", todo);
    }
  }
}
