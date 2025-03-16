using Application.Interfaces.Repositories.Read;
using Application.Interfaces.Repositories.Write;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands
{
    internal class CreateDrugCommandHandler(
        IDrugWriteRepository drugWriteRepository, 
        ICountryReadRepository countryReadRepository) 
        : IRequestHandler<CreateDrugCommand, Guid>
    {
        public async Task<Guid> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
        {
            var countries = await countryReadRepository.SearchCountriesByNameAsync(request.CountryName, cancellationToken);

            if(countries.Count <- 0)
            {
                throw new KeyNotFoundException(message: $"Страна с именем {request.CountryName} не найдена");
            }

            var drug = new Drug(request.Name, request.Manufacturer, countries.First().Code, countries.First(), null);

            await drugWriteRepository.AddAsync(drug, cancellationToken);

            return drug.Id;
        
        }
    }
}
