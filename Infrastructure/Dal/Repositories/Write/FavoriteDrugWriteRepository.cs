using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class FavoriteDrugWriteRepository(DbContext context) : BaseWriteRepository<Drug>(context)
{
    
}