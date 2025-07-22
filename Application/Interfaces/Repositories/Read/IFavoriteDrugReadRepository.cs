using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IFavoriteDrugReadRepository : IReadRepository<FavoriteDrug>
{
    Task<List<FavoriteDrug>> GetFavoriteDrugsByProfileIdAsync(Guid profileId, CancellationToken cancellationToken);
}
