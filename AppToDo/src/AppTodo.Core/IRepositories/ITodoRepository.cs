using System;
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
    /// Delete task
    /// </summary>
    /// <param name="Id">Id of the object.</param>
    /// <returns></returns>
    Task Delete(Guid Id);
  }
}
