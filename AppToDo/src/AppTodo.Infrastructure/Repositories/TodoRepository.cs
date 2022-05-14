using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTodo.Core.Entities;
using AppTodo.Core.IRepositories;
using AppTodo.Core.Queries;
using AppTodo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AppTodo.Infrastructure.Repositories
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 11/05/2022
  /// 
  /// The Repository pattern mediates between the domain and data mapping layers
  /// </summary>
  public class TodoRepository : ITodoRepository
  {
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
      _context = context;
    }

    public async Task Create(TodoItem todo)
    {
      await _context.AddAsync(todo);
      await _context.SaveChangesAsync();
    }

    public async Task Update(TodoItem todo)
    {
      _context.Todos.Update(todo);
      await _context.SaveChangesAsync();
    }

    public async Task<TodoItem> GetByIdAndUser(Guid id, string user)
    {
      return await _context.Todos
                           .AsNoTracking()
                           .FirstOrDefaultAsync(TodoQueries.GetByIdAndUser(id, user));
    }

    public async Task<IEnumerable<TodoItem>> GetAll(string user)
    {
      return await _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetAll(user))
                           .OrderBy(x => x.Date)
                           .ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllDone(string user)
    {
      return await _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetAllDone(user))
                           .OrderBy(x => x.Date)
                           .ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllUndone(string user)
    {
      return await _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetAllUndone(user))
                           .OrderBy(x => x.Date)
                           .ToListAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetByPeriod(string user, DateTime date, bool done)
    {
      return await _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetByPeriod(user, date, done))
                           .OrderBy(x => x.Date)
                           .ToListAsync();
    }
  }
}
