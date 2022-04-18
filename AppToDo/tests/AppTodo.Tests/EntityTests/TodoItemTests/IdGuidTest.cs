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
  /// Test the type Guid.
  /// </summary>
  public class IdGuidTest
  {
    [Fact(DisplayName = "Check Guid")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void Number_Check_NotBeEmpty()
    {
      //arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //assert
      todoItem.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
    }

    [Fact(DisplayName = "Check Guid")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void Number_Check_Teste()
    {
      //arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //act
      var resultado = todoItem.Id;

      //assert
      resultado.ToByteArray().Should().HaveCount(16);
    }

  }
}
