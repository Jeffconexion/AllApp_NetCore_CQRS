using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTodo.Application.Commands;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.CommandTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 27/04/2022
  /// 
  /// Tests my command UpdateTodoCommandTests.
  /// </summary>
  public class UpdateTodoCommandTests
  {
    [Fact(DisplayName = "Check all properties.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateMarkTodo_Command_CheckNotEmptyProperties()
    {
      // arrange
      var guid = Guid.NewGuid();
      UpdateTodoCommand command = new UpdateTodoCommand(guid, "Teste", "Carlos");

      //assert
      command.Id.Should().NotBeEmpty().And.Be(guid);
      command.Title.Should().NotBeNullOrEmpty().And.Be("Teste");
      command.User.Should().NotBeNullOrEmpty().And.Be("Carlos");

    }

    [Fact(DisplayName = "Check all properties is empty.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateMarkTodo_Command_CheckIsEmptyProperties()
    {
      // arrange      
      UpdateTodoCommand command = new UpdateTodoCommand();

      //assert
      command.Id.Should().BeEmpty();
      command.Title.Should().BeNullOrWhiteSpace();
      command.User.Should().BeNullOrWhiteSpace();
    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_Invalid()
    {
      // arrange
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.Empty, "", "");

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
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.NewGuid(), "Teste", "Carlos");

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
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.Empty, "","");

      //act
      command.Validate();

      //assert
      command.Id.Should().Be(Guid.Empty);
      command.Notifications.Should().NotBeEmpty().And.HaveCount(2);

    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsTwo()
    {
      // arrange
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.Empty, " ","");

      //act
      command.Validate();
      var message = command.Notifications.Select(u => u.Message).First();
      var propriedade = command.Notifications.Select(a => a.Property).First();
      var propriedade2 = command.Notifications.Select(a => a.Property).Skip(1).First();

      //assert
      command.Id.Should().Be(Guid.Empty);
      message.Should().NotBeNullOrEmpty().And.Contain("Por favor, descreva melhor esta tarefa!").And.BeOfType<string>();
      propriedade.Should().NotBeNullOrEmpty().And.Contain("Title").And.BeOfType<string>();
      propriedade2.Should().NotBeNullOrEmpty().And.Contain("User").And.BeOfType<string>();

    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsThree()
    {
      // arrange
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.Empty, "Teste", "");

      //act
      command.Validate();
      var message = command.Notifications.Select(u => u.Message).First();
      var propriedade = command.Notifications.Select(a => a.Property).First();

      //assert
      command.Id.Should().Be(Guid.Empty);
      message.Should().NotBeNullOrEmpty().And.Contain("Usuário inválido!").And.BeOfType<string>();
      propriedade.Should().NotBeNullOrEmpty().And.Contain("User").And.BeOfType<string>();

    }

    [Fact(DisplayName = "Check if command is valid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_ValidNotifications()
    {
      // arrange
      UpdateTodoCommand command = new UpdateTodoCommand(Guid.NewGuid(), "Teste", "Carlos");

      //act
      command.Validate();

      //assert
      command.Notifications.Should().BeNullOrEmpty().And.HaveCount(0);
      command.Valid.Should().BeTrue().And.Be(true);
    }

  }
}
