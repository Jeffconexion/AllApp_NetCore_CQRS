using System;
using System.Linq;
using AppTodo.Application.Commands.Handlers.MarkTodoAsDone;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.CommandTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 27/04/2022
  /// 
  /// Tests my command MarkTodoAsDoneCommandTests.
  /// </summary>
  public class MarkTodoAsDoneCommandTests
  {
    [Fact(DisplayName = "Check all properties.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateMarkTodo_Command_CheckNotEmptyProperties()
    {
      // arrange
      var guid = Guid.NewGuid();
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(guid, "Carlos");

      //assert
      command.Id.Should().NotBeEmpty().And.Be(guid);
      command.User.Should().NotBeNullOrEmpty().And.Be("Carlos");
    }

    [Fact(DisplayName = "Check all properties is empty.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateMarkTodo_Command_CheckIsEmptyProperties()
    {
      // arrange      
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand();

      //assert
      command.Id.Should().BeEmpty();
      command.User.Should().BeNullOrWhiteSpace();
    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_Invalid()
    {
      // arrange
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(Guid.Empty, "");

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
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(Guid.NewGuid(), "Carlos");

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
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(Guid.Empty, "");

      //act
      command.Validate();

      //assert
      command.Id.Should().Be(Guid.Empty);
      command.Notifications.Should().NotBeEmpty().And.HaveCount(1);

    }

    [Fact(DisplayName = "Check if command is invalid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_InvalidNotificationsTwo()
    {
      // arrange
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(Guid.Empty, " ");

      //act
      command.Validate();
      var message = command.Notifications.Select(u => u.Message).First();
      var propriedade = command.Notifications.Select(a => a.Property).First();

      //assert
      command.Id.Should().Be(Guid.Empty);
      message.Should().NotBeNullOrEmpty().And.Contain("Usuário inválido").And.BeOfType<string>();
      propriedade.Should().NotBeNullOrEmpty().And.Contain("User").And.BeOfType<string>();
    }

    [Fact(DisplayName = "Check if command is valid.")]
    [Trait("Commands", "To do many tests with command.")]
    public void CreateTodo_Command_ValidNotifications()
    {
      // arrange
      MarkTodoAsDoneCommand command = new MarkTodoAsDoneCommand(Guid.NewGuid(), "Carlos");

      //act
      command.Validate();

      //assert
      command.Notifications.Should().BeNullOrEmpty().And.HaveCount(0);
      command.Valid.Should().BeTrue().And.Be(true);
    }
  }
}
