using AppTodo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTodo.Infrastructure.Mappings
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 10/05/2022
  /// 
  /// Map database to ORM entityframework.
  /// </summary>
  public class TodoItemMap : IEntityTypeConfiguration<TodoItem>
  {
    public void Configure(EntityTypeBuilder<TodoItem> entity)
    {
      entity.ToTable("Todo");

      entity.HasKey(t => t.Id);
      entity.Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
      entity.Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
      entity.Property(x => x.Done);
      entity.Property(x => x.Date);
    }
  }
}
