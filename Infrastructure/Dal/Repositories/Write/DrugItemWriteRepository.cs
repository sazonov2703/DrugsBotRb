using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class DrugItemWriteRepository(DbContext context) : BaseWriteRepository<DrugItem>(context)
{
    
}