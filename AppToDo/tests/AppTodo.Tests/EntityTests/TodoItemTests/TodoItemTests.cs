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
  /// Test method and properties.
  /// </summary>
  public class TodoItemTests
  {
    [Fact(DisplayName = "Check if Done is true")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_MarkAsDone_ReturnTrue()
    {
      // arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      // act
      todoItem.MarkAsDone();

      // assert
      todoItem.Done.Should().BeTrue().And.Be(true);
    }

    [Fact(DisplayName = "Check if Done is false")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_MarkAsUndone_ReturnFalse()
    {
      // arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      // act
      todoItem.MarkAsUndone();

      // assert
      todoItem.Done.Should().BeFalse().And.Be(false);
    }

    [Fact(DisplayName = "Check if change title")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_UpdateTitle_CheckChangeTitle()
    {
      // arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      // act
      todoItem.UpdateTitle("Teste2");

      // assert
      todoItem.Title.Equals("Teste2");
    }

    [Fact(DisplayName = "Check User")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_Check_CheckValueUser()
    {
      // arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      // assert
      todoItem.User.Equals("Carlos");
    }

    [Fact(DisplayName = "Check Date")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_Check_CheckValueDate()
    {
      // arrange
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      // act
      var resultado = todoItem.Date;

      // assert
      todoItem.Date.Equals(resultado);
    }
  }
}
