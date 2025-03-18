using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

public class CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository) : IRequestHandler<CreateDrugStoreCommand, Guid>
{
    public async Task<Guid> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        DrugStore drugStore = new DrugStore(request.DrugNetwork, request.Number, request.Address);
        
        await drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        
        return drugStore.Id;
    }
}