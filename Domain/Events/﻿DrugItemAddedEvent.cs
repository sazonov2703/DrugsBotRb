using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие добавления нового товара в аптеку.
/// </summary>
public sealed class DrugItemAddedEvent : IDomainEvent
{
    public DrugItemAddedEvent(Guid drugItemId, Guid drugId, Guid drugStoreId, decimal price, double count)
    {
        DrugItemId = drugItemId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Price = price;
        Count = count;
        AddedAt = DateTime.UtcNow;
    }

    public Guid DrugItemId { get; }
    public Guid DrugId { get; }
    public Guid DrugStoreId { get; }
    public decimal Price { get; }
    public double Count { get; }
    public DateTime AddedAt { get; }
}
