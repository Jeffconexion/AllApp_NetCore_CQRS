using System;

namespace AppTodo.Core.Entities
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 03/04/2022
  /// 
  /// TodoItem is a new task to create.
  /// </summary>
  public class TodoItem : EntityBase
  {
    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public string User { get; private set; } //external user from google.

    public TodoItem(string title, bool done, DateTime date, string user)
    {
      Title = title;
      Done = done;
      Date = date;
      User = user;
    }

    /// <summary>
    /// Set with done my task
    /// </summary>
    public void MarkAsDone()
    {
      Done = true;
    }

    /// <summary>
    /// Set with undone my task
    /// </summary>
    public void MarkAsUndone()
    {
      Done = false;
    }

    /// <summary>
    /// Update title
    /// </summary>
    /// <param name="title">tile for update</param>
    public void UpdateTitle(string title)
    {
      Title = title;
    }

  }
}
