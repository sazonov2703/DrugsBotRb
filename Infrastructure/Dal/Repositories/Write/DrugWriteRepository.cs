using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class DrugWriteRepository(DbContext context) : BaseWriteRepository<Drug>(context)
{
    
}