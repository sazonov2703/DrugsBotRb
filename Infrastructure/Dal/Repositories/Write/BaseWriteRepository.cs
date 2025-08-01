﻿using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public abstract class BaseWriteRepository<T>(DbContext context) : IWriteRepository<T> where T : class
{
    protected readonly DbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Add(entity);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    { 
        var entity = _dbSet.Find(id);

        if (entity != null)
        {
            throw new KeyNotFoundException($"Сущность {typeof(T).Name} с Id {id} не найдена.");
        }
        
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}