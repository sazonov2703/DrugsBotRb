using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface IProfileWriteRepository : IWriteRepository<Profile>
{
    Task UpdateEmailAsync(Guid id, string newEmail, CancellationToken cancellationToken);
}
