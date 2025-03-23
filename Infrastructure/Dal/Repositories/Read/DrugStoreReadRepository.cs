using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class DrugStoreReadRepository(DbContext context) : BaseReadRepository<DrugStore>(context)
{
    
}