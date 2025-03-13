using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
    Task<List<DrugStore>> GetDrugStoresByNetworkAsync(string drugNetwork, CancellationToken cancellationToken);
}
