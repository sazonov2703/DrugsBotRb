using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
    Task<List<DrugStore>> GetDrugStoresByNetworkAsync(string drugNetwork, CancellationToken cancellationToken);
    Task<List<DrugStore>> SearchDrugStoresByNameAsync(string name, CancellationToken cancellationToken);
}
