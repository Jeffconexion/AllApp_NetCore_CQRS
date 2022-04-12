using System;
using AppTodo.Application.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppTodo.Application.Commands
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 09/04/2022
  /// 
  /// Class command is similar a viewModel or Dtos
  /// Make a task as undone.
  /// </summary>
  public class MarkTodoAsUndoneCommand : Notifiable, ICommand
  {
    public Guid Id { get; set; }
    public string User { get; set; }

    public MarkTodoAsUndoneCommand()
    {
    }

    public MarkTodoAsUndoneCommand(Guid id, string user)
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
