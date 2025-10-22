namespace VB.HotChocoBoard.Domain.Abstraction.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }

    public DateTime CreatedAt { get; protected set; } = DateTime.Now;
}