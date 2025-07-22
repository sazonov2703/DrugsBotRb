using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class CountryWriteRepository(DbContext context) : BaseWriteRepository<Country>(context)
{
    
}