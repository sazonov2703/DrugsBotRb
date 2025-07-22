using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Событие изменения цены товара в аптеке.
/// </summary>
public sealed class DrugItemPriceUpdatedEvent : IDomainEvent
{
    public DrugItemPriceUpdatedEvent(Guid drugItemId, Guid drugId, Guid drugStoreId, decimal oldPrice, decimal newPrice)
    {
        DrugItemId = drugItemId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        OldPrice = oldPrice;
        NewPrice = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }

    public Guid DrugItemId { get; }
    public Guid DrugId { get; }
    public Guid DrugStoreId { get; }
    public decimal OldPrice { get; }
    public decimal NewPrice { get; }
    public DateTime UpdatedAt { get; }
}
