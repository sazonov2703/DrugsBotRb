using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class DrugStoreWriteRepository(DbContext context) : BaseWriteRepository<DrugStore>(context)
{
    
}