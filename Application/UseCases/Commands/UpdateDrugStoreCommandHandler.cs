using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using MediatR;

namespace Application.UseCases.Commands;

public class UpdateDrugStoreCommandHandler(
    IDrugStoreWriteRepository drugStoreWriteRepository,
    IDrugStoreReadRepository drugStoreReadRepository) 
    : IRequestHandler<UpdateDrugStoreCommand, Guid>
{
    public async Task<Guid> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStores = await drugStoreReadRepository.SearchDrugStoresByNameAsync(request.Name, cancellationToken);
        
        if (drugStores.Count < -0)
        {
            throw new KeyNotFoundException(message: $"Аптека с именем {request.Name} не найдена");
        }
        
        var drugStore = drugStores.First();
        
        drugStore.Update(request.NewDrugNetwork, request.NewNumber, request.NewAddress);

        await drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
        
        return drugStore.Id;
    }
}