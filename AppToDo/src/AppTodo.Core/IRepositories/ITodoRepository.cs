using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppTodo.Core.Entities;

namespace AppTodo.Core.IRepositories
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 12/04/2022
  /// 
  /// Interface repository pattern responsible for data persistence.
  /// </summary>
  public interface ITodoRepository
  {
    /// <summary>
    /// Create new task.
    /// </summary>
    /// <param name="todo">Object of the type TodoItem</param>
    /// <returns></returns>
    Task Create(TodoItem todo);

    /// <summary>
    /// Update task.
    /// </summary>
    /// <param name="todo">Object of the type TodoItem</param>
    /// <returns></returns>
    Task Update(TodoItem todo);

    /// <summary>
    /// Get all tasks.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IEnumerable<TodoItem>> GetAll(string user);

    /// <summary>
    /// Get all tasks are with done.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IEnumerable<TodoItem>> GetAllDone(string user);

    /// <summary>
    /// Get all tasks are with undone.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IEnumerable<TodoItem>> GetAllUndone(string emuserail);

    /// <summary>
    /// Get all tasks are betwee period.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IEnumerable<TodoItem>> GetByPeriod(string user, DateTime date, bool done);

    /// <summary>
    /// Get specify id and user.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<TodoItem> GetByIdAndUser(Guid id, string user);
  }
}
