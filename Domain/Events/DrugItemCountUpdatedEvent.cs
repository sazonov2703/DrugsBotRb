using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие изменения цены товара в аптеке.
/// </summary>
public sealed class DrugItemCountUpdatedEvent : IDomainEvent
{
    public DrugItemCountUpdatedEvent(Guid drugItemId, Guid drugId, Guid drugStoreId, double oldCount, double newCount)
    {
        DrugItemId = drugItemId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        OldCount = oldCount;
        NewCount = newCount;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid DrugItemId { get; }
    public Guid DrugId { get; }
    public Guid DrugStoreId { get; }
    public double OldCount { get; }
    public double NewCount { get; }
    public DateTime UpdatedAt { get; }
}
