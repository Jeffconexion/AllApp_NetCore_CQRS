using System;
using AppTodo.Application.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppTodo.Application.Commands
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 07/04/2022
  /// 
  /// CreateTodoCommand is similar a viewModel or a DTO.
  /// It goes bind with date from user.
  /// </summary>
  public class CreateTodoCommand : Notifiable, ICommand
  {
    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    public CreateTodoCommand()
    {
    }

    public CreateTodoCommand(string title, string user, DateTime date)
    {
      Title = title;
      User = user;
      Date = date;
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
