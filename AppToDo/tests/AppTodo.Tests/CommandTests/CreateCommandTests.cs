using System;
using System.Linq;
using AppTodo.Application.Commands;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.CommandTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 07/04/2022
  /// 
  /// Tests my command CreateTodoCommandTests.
  /// </summary>
  public class CreateCommandTests
  {

    [Fact(DisplayName = "Check all properties.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_CheckNotEmptyProperties()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("Teste", "Carlos", DateTime.Now);

      //assert
      command.Title.Should().NotBeNullOrWhiteSpace();
    }

    [Fact(DisplayName = "Check all properties.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_CheckIsEmptyProperties()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand(" ", " ", DateTime.Now);

      //assert
      command.Title.Should().BeNullOrWhiteSpace();
    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_Invalid()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("", "", DateTime.Now);

      //act
      command.Validate();

      //assert
      command.Valid.Should().BeFalse();

    }

    [Fact(DisplayName = "Check if command is valid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_valid()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("Teste", "Carlos", DateTime.Now);

      //act
      command.Validate();

      //assert
      command.Valid.Should().BeTrue();

    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsOne()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("", "", DateTime.Now);

      //act
      command.Validate();

      //assert
      command.Notifications.Should().NotBeEmpty().And.HaveCount(2);

    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsTwo()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("", "Carlos", DateTime.Now);

      //act
      command.Validate();
      var mensagem = command.Notifications.Select(a => a.Message).First();
      var propriedade = command.Notifications.Select(a => a.Property).First();

      //assert
      mensagem.Should().NotBeNullOrEmpty().And.Contain("Por favor, descreva melhor esta tarefa!").And.BeOfType<string>();
      propriedade.Should().NotBeNullOrEmpty().And.Contain("Title").And.BeOfType<string>();


    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsThree()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("Teste", "", DateTime.Now);

      //act
      command.Validate();
      var mensagem = command.Notifications.Select(a => a.Message).First();
      var propriedade = command.Notifications.Select(a => a.Property).First();

      //assert
      mensagem.Should().NotBeNullOrEmpty().And.Contain("Usuário inválido!").And.BeOfType<string>();
      propriedade.Should().NotBeNullOrEmpty().And.Contain("User").And.BeOfType<string>();

    }

    [Fact(DisplayName = "Check if command is valid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_ValidNotifications()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("Teste", "Carlos", DateTime.Now);

      //act
      command.Validate();

      //assert
      command.Notifications.Should().BeNullOrEmpty().And.HaveCount(0);

    }
  }
}
