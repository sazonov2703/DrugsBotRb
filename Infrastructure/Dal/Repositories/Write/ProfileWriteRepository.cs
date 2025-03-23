using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Write;

public class ProfileWriteRepository(DbContext context) : BaseWriteRepository<Profile>(context)
{
    
}