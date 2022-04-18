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
  /// Test if the type object
  /// </summary>
  public class TodoItemTests
  {
    [Fact(DisplayName = "Check if object your type is TodoItem.")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_Create_ReturnObjectTodoItem()
    {
      //arrange //act
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //assertion
      todoItem.Should().BeOfType<TodoItem>();
    }

    [Fact(DisplayName = "Check if object your type is TodoItem.")]
    [Trait("TodoItem", "To do many tests in entity.")]
    public void TodoItem_Check_ReturnDerivedType()
    {
      //arrange and act
      TodoItem todoItem = new TodoItem("Teste", "Carlos", DateTime.Now);

      //assertion
      todoItem.Should().BeAssignableTo<EntityBase>();
    }

  }
}
