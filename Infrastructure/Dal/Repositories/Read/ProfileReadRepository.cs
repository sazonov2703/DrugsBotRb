using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class ProfileReadRepository(DbContext context) : BaseReadRepository<Profile>(context)
{
    
}