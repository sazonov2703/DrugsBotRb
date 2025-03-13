using Domain.Events;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// Аптека
/// </summary>
public sealed class DrugStore : BaseEntity<DrugStore>
{
    public DrugStore(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;

        // Вызов валидации через базовый класс
        ValidateEntity(new DrugStoreValidator());
    }

    /// <summary>
    /// Сеть аптек, к которой принадлежит аптека.
    /// </summary>
    public string DrugNetwork { get; private set; }

    /// <summary>
    /// Номер аптеки в сети.
    /// </summary>
    public int Number { get; private set; }

    /// <summary>
    /// Адрес аптеки.
    /// </summary>
    public Address Address { get; private set; }

    // Навигационное свойство для связи с DrugItem
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

    #region Методы

    public void RemoveDrugItem(DrugItem drugItem)
    {
        DrugItems.Remove(drugItem);
        AddDomainEvent(new DrugItemRemovedEvent(drugItem.Id, drugItem.DrugId, drugItem.DrugStoreId));
    }

    public void AddDrugItem(DrugItem drugItem)
    {
        DrugItems.Add(drugItem);
        AddDomainEvent(new DrugItemAddedEvent(drugItem.Id, drugItem.DrugId, drugItem.DrugStoreId, drugItem.Cost, drugItem.Count));
    }

    #endregion
}