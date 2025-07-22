using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Domain.Entities;

/// <summary>
/// Базовый класс для всех сущностей домена, обеспечивающий сравнение по идентификатору и валидацию.
/// </summary>
public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    /// <summary>
    /// Лист доменных событий.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Конструктор по умолчанию, инициализирующий новый уникальный идентификатор.
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public Guid Id { get; protected init; }

    #region Методы

    /// <summary>
    /// Выполняет валидацию сущности с использованием указанного валидатора.
    /// </summary>
    /// <param name="validator">Валидатор FluentValidator.</param>
    protected void ValidateEntity(AbstractValidator<T> validator)
    {
        var validationResult = validator.Validate((T)this);
        if (validationResult.IsValid)
        {
            return;
        }

        var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException(errorMessages);
    }

    #region Системные методы

    /// <summary>
    /// Переопределение метода Equals для сравнения сущностей по идентификатору.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj.GetType() != GetType()) return false;

        return Id.Equals(((BaseEntity<T>)obj).Id);
    }

    /// <summary>
    /// Переопределение метода GetHashCode для получения хеш-кода на основе уникального идентификатора.
    /// </summary>
    /// <returns>Хеш-код, основанный на значении идентификатора.</returns>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Оператор равенства для сравнения двух экземпляров BaseEntity по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность для сравнения.</param>
    /// <param name="right">Правая сущность для сравнения.</param>
    /// <returns>True, если сущности равны; иначе False.</returns>
    public static bool operator ==(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    /// <summary>
    /// Оператор неравенства для сравнения двух экземпляров BaseEntity по идентификатору.
    /// </summary>
    /// <param name="left">Левая сущность для сравнения.</param>
    /// <param name="right">Правая сущность для сравнения.</param>
    /// <returns>True, если сущности не равны; иначе False.</returns>
    public static bool operator !=(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        return !(left == right);
    }

    #endregion

    #endregion

    #region Методы доменных событий

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    #endregion
}