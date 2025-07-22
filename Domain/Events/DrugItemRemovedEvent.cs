using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие удаления товара из аптеки.
/// </summary>
public sealed class DrugItemRemovedEvent : IDomainEvent
{
    public DrugItemRemovedEvent(Guid drugItemId, Guid drugId, Guid drugStoreId)
    {
        DrugItemId = drugItemId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        RemovedAt = DateTime.UtcNow;
    }

    public Guid DrugItemId { get; }
    public Guid DrugId { get; }
    public Guid DrugStoreId { get; }
    public DateTime RemovedAt { get; }
}
