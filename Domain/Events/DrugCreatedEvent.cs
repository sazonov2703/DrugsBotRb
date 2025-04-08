using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Events
{
    /// <summary>
    /// Событие создания нового товара.
    /// </summary>
    public class DrugCreatedEvent : IDomainEvent
    {
        public DrugCreatedEvent(Guid drugId, string name, string manufacturer, Guid countryId, Country country, Func<string, bool> countryExistsFunc)
        {
            DrugId = drugId;
            Name = name;
            Manufacturer = manufacturer;
            CountryId = countryId;
            Country = country;
            CreatedAt = DateTime.UtcNow;
        }
        public Guid DrugId { get; }
        public string Name { get; }
        public string Manufacturer { get; }
        public Guid CountryId { get; }
        public Country Country { get; }
        public DateTime CreatedAt { get; }
    }
}
