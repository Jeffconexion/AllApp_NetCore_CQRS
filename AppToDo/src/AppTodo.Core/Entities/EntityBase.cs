using System;

namespace AppTodo.Core.Entities
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 03/04/2022
  /// 
  /// Base entity that has codes in common for the other entities.
  /// Responsible for generating the Identified of the entity, in this way
  /// leaving responsibility on the domain and not on the database.
  /// </summary>
  public abstract class EntityBase : IEquatable<EntityBase>
  {
    public Guid Id { get; private set; }

    protected EntityBase()
    {
      Id = Guid.NewGuid();
    }

    /// <summary>
    /// compare whether two entities are the same.
    /// </summary>
    /// <param name="entityOther"> Other entitys</param>
    /// <returns>true if the same, false if not same</returns>
    public bool Equals(EntityBase entityOther)
    {
      if (GuidIsEqual(entityOther))
      {
        return true;
      }
      return false;
    }

    private bool GuidIsEqual(EntityBase entityOther)
    {
      return Id == entityOther.Id;
    }
  }
}
