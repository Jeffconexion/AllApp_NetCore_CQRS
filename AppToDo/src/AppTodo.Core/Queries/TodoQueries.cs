using System;
using System.Linq.Expressions;
using AppTodo.Core.Entities;

namespace AppTodo.Core.Queries
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 11/05/2022
  /// 
  /// return express.
  /// </summary>
  public static class TodoQueries
  {
    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Expression<Func<TodoItem, bool>> GetAll(string user)
    {
      return x => x.User == user;
    }

    /// <summary>
    /// Get all tasks are with done.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
    {
      return x => x.User == user && x.Done;
    }

    /// <summary>
    /// Get all tasks are with undone.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
    {
      return x => x.User == user && x.Done == false;
    }

    /// <summary>
    /// Get all tasks are betwee period.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="date"></param>
    /// <param name="done"></param>
    /// <returns></returns>
    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
    {
      return x =>
                 x.User == user &&
                 x.Done == done &&
                 x.Date.Date == date.Date;
    }

    /// <summary>
    /// Get specify id and user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Expression<Func<TodoItem, bool>> GetByIdAndUser(Guid id, string user)
    {
      return x =>
                x.Id == id &&
                x.User == user;
    }

  }
}
