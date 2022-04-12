using System;
using AppTodo.Application.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppTodo.Application.Commands
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 11/04/2022
  /// 
  /// Class command is similar a viewModel or Dtos
  /// update task.
  /// </summary>
  public class UpdateTodoCommand : Notifiable, ICommand
  {

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public UpdateTodoCommand()
    {
    }
    public UpdateTodoCommand(Guid id, string title, string user)
    {
      Id = id;
      Title = title;
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
        .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
        .HasMinLen(User, 6, "User", "Usuário inválido!")
      );
    }
  }
}
