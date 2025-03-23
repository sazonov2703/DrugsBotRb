using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class DrugReadRepository(DbContext context) : BaseReadRepository<Drug>(context)
{
    
}