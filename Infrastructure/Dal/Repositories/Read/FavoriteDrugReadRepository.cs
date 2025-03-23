using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

public class FavoriteDrugReadRepository(DbContext context) : BaseReadRepository<FavoriteDrug>(context)
{
    
}