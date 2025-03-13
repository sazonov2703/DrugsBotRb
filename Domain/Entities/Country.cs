using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации страны с названием и кодом.
        /// </summary>
        /// <param name="name">Название страны. Обязательное поле.</param>
        /// <param name="code">Код страны. Обязательное поле.</param>
        public Country(string name, string code)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhitespaceMessage);
            Code = Guard.Against.NullOrWhiteSpace(code, nameof(code), ValidationMessage.NullOrWhitespaceMessage);

            /// <summary>
            /// Валидация переданых параметров
            /// </summary>
            var validator = new CountryValidator();
            validator.Validate(this);
        }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Код страны (например, ISO-код).
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Навигационное свойство для связи с препаратами.
        /// </summary>
        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();

        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
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
    }
}