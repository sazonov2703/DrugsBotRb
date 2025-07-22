using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugItemReadRepository : IReadRepository<DrugItem>
{
    Task<List<DrugItem>> GetDrugItemsByStoreIdAsync(Guid drugStoreId, CancellationToken cancellationToken);
}
