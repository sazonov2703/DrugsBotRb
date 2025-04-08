using Domain.Events;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Связь между препаратом и аптекой
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
    /// <summary>
    /// Пустой конструктор для EF core.
    /// </summary>
    private DrugItem()
    {
        
    }
    
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;

        // Вызов валидации через базовый класс
        ValidateEntity(new DrugItemValidator());
    }

    #region Свойства

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid DrugStoreId { get; private set; }

    /// <summary>
    /// Стоимость препарата в данной аптеке.
    /// </summary>
    public decimal Cost { get; private set; }

    /// <summary>
    /// Количество препарата на складе.
    /// </summary>
    public double Count { get; private set; }

    // Навигационные свойства
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }

    #endregion

    #region Методы

    public void UpdateCount(double newCount)
    {
        var oldCount = Count;
        Count = newCount;
        ValidateEntity(new DrugItemValidator());
        AddDomainEvent(new DrugItemCountUpdatedEvent(Id, DrugId, DrugStoreId, oldCount, newCount));
    }

    public void UpdatePrice(decimal newPrice)
    {
        var oldPrice = Cost;
        Cost = newPrice;
        ValidateEntity(new DrugItemValidator());
        AddDomainEvent(new DrugItemPriceUpdatedEvent(Id, DrugId, DrugStoreId, oldPrice, newPrice));
    }


    #endregion
}