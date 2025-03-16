using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
    Task RemoveFavoriteDrugAsync(Guid profileId, Guid drugId, CancellationToken cancellationToken);
}
