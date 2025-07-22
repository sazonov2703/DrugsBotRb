using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
    Task UpdateDrugStoreAddressAsync(Guid id, string newAddress, CancellationToken cancellationToken);
}
