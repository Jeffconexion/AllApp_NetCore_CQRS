using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AppTodo.Core.Entities;

namespace AppTodo.Core.Queries
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 11/05/2022
  /// 
  /// return express.
  /// -----> change for CQRS
  /// </summary>
  public static class TodoQueries
  {
    public static Expression<Func<TodoItem, bool>> GetAll(string user)
    {
      return x => x.User == user;
    }

    public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
    {
      return x => x.User == user && x.Done;
    }

    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
    {
      return x => x.User == user && x.Done == false;
    }

    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
    {
      return x =>
                 x.User == user &&
                 x.Done == done &&
                 x.Date.Date == date.Date;
    }

  }
}
