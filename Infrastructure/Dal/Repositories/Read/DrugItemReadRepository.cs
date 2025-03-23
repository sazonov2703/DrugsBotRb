using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class DrugItemReadRepository(DbContext context) : BaseReadRepository<DrugItem>(context)
{
    
}