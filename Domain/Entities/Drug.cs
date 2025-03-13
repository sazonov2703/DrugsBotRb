using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Drug : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации класса с препаратом.
        /// </summary>
        /// <param name="name">Название препарата. Обязательное поле.</param>
        /// <param name="manufacturer">Производитель. Обязательное поле.</param>
        /// <param name="countryCodeId">Код страны(ISO). Обязательное поле.</param>
        public Drug(string name, string manufacturer, string countryCodeId)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhitespaceMessage);
            Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer), ValidationMessage.NullOrWhitespaceMessage);
            CountryCodeId = Guard.Against.NullOrWhiteSpace(countryCodeId, nameof(countryCodeId), ValidationMessage.NullOrWhitespaceMessage);

            /// <summary>
            /// Валидация переданых параметров
            /// </summary>
            var validator = new DrugValidator();
            validator.Validate(this);
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
        /// Код страны производителя.
        /// </summary>
        public string CountryCodeId { get; private set; }

        /// <summary>
        /// Связь с объектом Country.
        /// </summary>
        public Country Country { get; private set; }

        /// <summary>
        /// Навигационное свойство для связи с DrugItem.
        /// </summary>
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    }
}