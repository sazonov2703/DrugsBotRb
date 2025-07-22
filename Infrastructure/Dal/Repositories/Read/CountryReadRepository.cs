using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class CountryReadRepository(DbContext context) : BaseReadRepository<Country>(context)
{
    
}