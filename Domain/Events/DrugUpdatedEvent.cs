using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Events;
/// <summary>
/// Событие создания нового товара.
/// </summary>
public class DrugUpdatedEvent : IDomainEvent
{
    public DrugUpdatedEvent(Guid drugId, string newName, string oldName, string newManufacturer, string oldManufacturer, string newCountryCodeId, string oldCountryCodeId, Country newCountry, Country oldCountry, Func<string, bool> countryExistsFunc)
    {
        DrugId = drugId;
        NewName = newName;
        OldName = oldName;
        NewManufacturer = newManufacturer;
        OldManufacturer = oldManufacturer;
        NewCountryCodeId = newCountryCodeId;
        OldCountryCodeId = oldCountryCodeId;
        NewCountry = newCountry;
        OldCountry = oldCountry;
        UpdatedAt = DateTime.UtcNow;
    }
    public Guid DrugId { get; }
    public string NewName { get; }
    public string OldName { get; }
    public string NewManufacturer { get; }
    public string OldManufacturer { get; }
    public string NewCountryCodeId { get; }
    public string OldCountryCodeId { get; }
    public Country NewCountry { get; }
    public Country OldCountry { get; }
    public DateTime UpdatedAt { get; }
}