﻿using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

public interface ICountryWriteRepository : IWriteRepository<Country>
{
    Task UpdateCountryNameAsync(Guid id, string newName, CancellationToken cancellationToken);
}