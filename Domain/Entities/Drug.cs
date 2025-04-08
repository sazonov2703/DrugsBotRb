using Domain.Events;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity<Drug>
{
    /// <summary>
    /// Пустой конструктор для EF core.
    /// </summary>
    private Drug()
    {
        
    }
    
    public Drug(string name, string manufacturer, Guid countryId, Country country, Func<string, bool> countryExistsFunc)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryId = countryId;
        Country = country;

        // Вызов валидации через базовый класс с использованием переданной функции проверки
        ValidateEntity(new DrugValidator(countryExistsFunc));

        // Выброс ивента создания товара
        AddDomainEvent(new DrugCreatedEvent(Id, Name, Manufacturer, CountryId, Country,null));
    }

    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Производитель препарата.
    /// </summary>
    public string Manufacturer { get; private set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Guid CountryId { get; private set; }

    /// <summary>
    /// Связь с объектом Country.
    /// </summary>
    public Country Country { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

    #region Методы
    
    /// <summary>
    /// Метод для обновления полей в товаре.
    /// </summary>
    public void Update(string newName, string newManufacturer, Guid newCountryId, Country newCountry, Func<string, bool> countryExistsFunc)
    {
        if (Name == newName && Manufacturer == newManufacturer && CountryId == CountryId)
        {
            return;
        }
        
        string oldName = Name;
        string oldManufacturer = Manufacturer;
        Guid oldCountryId = CountryId;
        Country oldCountry = Country;
        
        Name = newName;
        Manufacturer = newManufacturer;
        CountryId = newCountryId;
        Country = newCountry;

        // Вызов валидации через базовый класс с использованием переданной функции проверки
        ValidateEntity(new DrugValidator(countryExistsFunc));

        // Выброс события обновления препарата
        AddDomainEvent(new DrugUpdatedEvent(Id, newName, oldName, newManufacturer, oldManufacturer, newCountryId, oldCountryId, newCountry, oldCountry, null));
    }

    #endregion
}