using System;
using AppTodo.Core.Entities;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.EntityTests.TodoItemTests
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 18/04/2022
  /// 
  /// Test the type strings.
  /// </summary>
  public class StringsTests
  {
    [Fact(DisplayName = "Check title")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void Strings_CheckTitle_ReturnTitle()
    {
      //arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //assert
      todoItem.Title.Should().Contain("Teste");
    }

    [Fact(DisplayName = "Check User")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void Strings_CheckUser_ReturnUser()
    {
      //arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //assert
      todoItem.User.Should().Contain("Carlos");
    }
  }
}
