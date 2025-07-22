using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

public class CreateDrugItemCommandHandler(
    IDrugReadRepository drugReadRepository,
    IDrugStoreReadRepository drugStoreReadRepository,
    IDrugItemWriteRepository drugItemWriteRepository) 
    : IRequestHandler<CreateDrugItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugs = await drugReadRepository.SearchDrugsByName(request.DrugName, cancellationToken);
        
        if (drugs.Count() <- 0)
        {
            throw new KeyNotFoundException(message: $"Товар {request.DrugName} не найден");
        }

        var drugStores = await drugStoreReadRepository.SearchDrugStoresByNameAsync(request.DrugStoreName, cancellationToken);
        
        if (drugStores.Count() <- 0)
        {
            throw new KeyNotFoundException(message: $"Аптека {request.DrugStoreName} не найдена");
        }

        var drugItem = new DrugItem(drugs.First().Id, drugStores.First().Id, request.Cost, request.Count, drugs.First(), drugStores.First());

        return drugItem.Id;
    }
}