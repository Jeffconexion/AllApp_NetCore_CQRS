using System;
using AppTodo.Application.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppTodo.Application.Commands.Handlers.MarkTodoAsDone
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 09/04/2022
  /// 
  /// Class command is similar a viewModel or Dtos
  /// Make a task as done.
  /// </summary>
  public class MarkTodoAsDoneCommand : Notifiable, ICommand
  {
    public Guid Id { get; set; }
    public string User { get; set; }

    public MarkTodoAsDoneCommand()
    {
    }

    public MarkTodoAsDoneCommand(Guid id, string user)
    {
      Id = id;
      User = user;
    }

    /// <summary>
    /// Library flunt for validation
    /// </summary>
    public void Validate()
    {
      AddNotifications(
        new Contract()
            .Requires()
            .HasMinLen(User, 6, "User", "Usuário inválido!")
        );
    }
  }
}
