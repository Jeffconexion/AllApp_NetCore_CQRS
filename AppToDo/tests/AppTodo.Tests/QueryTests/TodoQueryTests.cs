using System;
using System.Collections.Generic;
using System.Linq;
using AppTodo.Core.Entities;
using AppTodo.Core.Queries;
using FluentAssertions;
using Xunit;

namespace AppTodo.Tests.QueryTests
{
  public class TodoQueryTests
  {
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
      _items = new List<TodoItem>();
      _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("Tarefa 3", "carlos", DateTime.Now));
      _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
      _items.Add(new TodoItem("Tarefa 5", "carlos", DateTime.Now));
    }

    [Fact(DisplayName = "Check Query is valid.")]
    [Trait("Querys", "To do many tests with Querys.")]
    public void Query_GetAll_ReturnDate()
    {
      var result = _items.AsQueryable().Where(TodoQueries.GetAll("carlos"));
      result.Should().NotBeEmpty().And.HaveCount(2);
    }

  }
}
