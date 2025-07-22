using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands;

public class CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository) : IRequestHandler<CreateDrugStoreCommand, Guid>
{
    public async Task<Guid> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var address = new Address(request.City, request.Street, request.House);
        
        var drugStore = new DrugStore(request.DrugNetwork, request.Number, address);
        
        await drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        
        return drugStore.Id;
    }
}