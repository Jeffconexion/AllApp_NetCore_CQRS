﻿using System;
using AppTodo.Application.Commands;
using AppTodo.Application.Commands.Handlers.CreateTodo;
using AppTodo.Core.IRepositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace AppTodo.Tests.HandlerTests.CreateTodoTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 26/04/2022
  /// 
  /// Tests my handler TodoHandlerTests.
  /// </summary>
  public class CreateTodoCommandHandlerTests
  {

    [Fact(DisplayName = "Check Handler is valid.")]
    [Trait("Handlers", "To do many tests with Handlers.")]
    public void Handler_CreateTaskIsValid_ReturnTrue()
    {
      //arrange
      var command = new CreateTodoCommand("Teste", "Carlos", DateTime.Now);
      var repository = new Mock<ITodoRepository>();
      var handler = new CreateTodoCommandHandler(repository.Object);

      //act
      var handlerResult = handler.Handle(command).Result.As<GenericCommandResult>();

      //assert
      handlerResult.Success.Should().BeTrue().And.Be(true).And.NotBe(false);
    }

    [Fact(DisplayName = "Check Handler is not valid.")]
    [Trait("Handlers", "To do many tests with Handlers.")]
    public void Handler_CreateTaskIsInvalid_ReturnFalse()
    {
      //arrange
      var command = new CreateTodoCommand("", "", DateTime.Now);
      var repository = new Mock<ITodoRepository>();
      var handler = new CreateTodoCommandHandler(repository.Object);

      //act
      var handlerResult = handler.Handle(command).Result.As<GenericCommandResult>();

      //assert
      handlerResult.Success.Should().BeFalse().And.Be(false).And.NotBe(true);
    }

  }
}
