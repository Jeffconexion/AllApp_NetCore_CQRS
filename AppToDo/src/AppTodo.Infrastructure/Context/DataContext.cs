using AppTodo.Core.Entities;
using AppTodo.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppTodo.Infrastructure.Context
{

  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 05/05/2022
  /// 
  /// representation of our database.
  /// </summary>
  public class DataContext : DbContext
  {
    public DbSet<TodoItem> Todos { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TodoItemMap());
    }
  }
}
