using System.Threading.Tasks;
using AppTodo.Application.Commands.Contracts;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Core.Entities;
using AppTodo.Core.IRepositories;
using Flunt.Notifications;

namespace AppTodo.Application.Commands.Handlers.UpdateTodo
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 04/05/2022
  ///
  /// Class to execution commands.
  /// </summary>
  public class UpdateTodoCommandHandler : Notifiable, IHandler<UpdateTodoCommand>
  {

    private readonly ITodoRepository _repository;

    public UpdateTodoCommandHandler(ITodoRepository repository)
    {
      _repository = repository;
    }

    /// <summary>
    /// Execution command Update task.
    /// </summary>
    /// <param name="command">Object command.</param>
    /// <returns></returns>
    public async Task<ICommandResult> Handle(UpdateTodoCommand command)
    {
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      //recover the todoItem
      TodoItem todo = await _repository.GetByIdAndUser(command.Id, command.User);

      //change title
      todo.UpdateTitle(command.Title);

      //save in database
      await _repository.Update(todo);

      return new GenericCommandResult(true, "Tarefa Salva", todo);
    }
  }
}
