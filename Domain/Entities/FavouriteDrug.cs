using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities;

/// <summary>
/// Избранный препарат.
/// </summary>
public class FavoriteDrug
{
    public FavoriteDrug(
        Guid profileId,
        Guid drugId,
        Drug drug,
        Guid? drugStoreId = null,
        DrugStore? drugStore = null)
    {
        ProfileId = profileId;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Drug = drug;
        DrugStore = drugStore;
    }

    /// <summary>
    /// Идентификатор профиля.
    /// </summary>
    public Guid ProfileId { get; private init; }

    /// <summary>
    /// Идентификатор препарата.
    /// </summary>
    public Guid DrugId { get; private set; }

    /// <summary>
    /// Идентификатор аптеки.
    /// </summary>
    public Guid? DrugStoreId { get; private set; }

    /// <summary>
    /// Навигационные свойства
    /// </summary>
    public Drug Drug { get; private set; }
    public DrugStore? DrugStore { get; private set; }
}
