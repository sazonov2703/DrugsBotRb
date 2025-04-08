using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using MediatR;

public class UpdateDrugCommandHandler(
    IDrugReadRepository drugReadRepository,
    IDrugWriteRepository drugWriteRepository,
    ICountryReadRepository countryReadRepository) 
    : IRequestHandler<UpdateDrugCommand, Guid>
{
    public async Task<Guid> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var countries = await countryReadRepository.SearchCountriesByNameAsync(request.NewCountryName, cancellationToken);
        
        if(countries.Count <- 0)
        {
            throw new KeyNotFoundException(message: $"Страна с именем {request.NewCountryName} не найдена");
        } 
        
        var drugs = await drugReadRepository.SearchDrugsByName(request.Name, cancellationToken);

        if (drugs.Count < -0)
        {
            throw new KeyNotFoundException(message: $"Товар с именем {request.Name} не найден");
        }
        
        var drug = drugs.First();
        
        drug.Update(request.NewName, request.NewManufacturer, countries.First().Id, countries.First(), null);
        
        await drugWriteRepository.UpdateAsync(drug, cancellationToken);
        
        return drug.Id;
    }
}