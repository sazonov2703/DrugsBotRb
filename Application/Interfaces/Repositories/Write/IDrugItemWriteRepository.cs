using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
    Task UpdateDrugItemPriceAsync(Guid id, decimal newPrice, CancellationToken cancellationToken);
}
