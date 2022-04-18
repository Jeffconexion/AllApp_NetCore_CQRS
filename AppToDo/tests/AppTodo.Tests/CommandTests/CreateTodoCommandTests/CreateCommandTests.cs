using System;
using AppTodo.Application.Commands;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.CommandTests.CreateTodoCommandTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 07/04/2022
  /// 
  /// Tests my command CreateTodoCommandTests.
  /// </summary>
  public class CreateCommandTests
  {
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

    [Fact(DisplayName = "Check if command is invalid.")]
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
    public void CreateTodo_Command_InvalidNotifications()
    {
      // arrange
      CreateTodoCommand command = new CreateTodoCommand("", "", DateTime.Now);

      //act
      command.Validate();

      //assert
      command.Notifications.Should().NotBeEmpty().And.HaveCount(2);

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
