﻿namespace ProjectE.Core.Entities;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();   
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }
    public Guid Id { get; }
    public DateTime? CreatedAt { get; }
    public bool IsDeleted { get; private set; } 
    public void SetEntityAsDeleted() => IsDeleted = true;

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }
    public static bool operator == (Entity a, Entity b)
    {
        if (ReferenceEquals(null, a) && ReferenceEquals(b, null)) return true;

        if (ReferenceEquals(null, a) || ReferenceEquals(b, null)) return false;

        return a.Equals(b);
    }
    public static bool operator !=(Entity a, Entity b) => !(a == b);
    public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();
    public override string ToString() => $"{GetType().Name} [Id ={Id}";
}
