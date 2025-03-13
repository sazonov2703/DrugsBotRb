using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface ICountryReadRepository : IReadRepository<Country>
{
    Task<List<Country>> SearchCountriesByNameAsync(string name, CancellationToken cancellationToken);
}
