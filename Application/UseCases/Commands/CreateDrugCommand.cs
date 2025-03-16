using MediatR;

namespace Application.UseCases.Commands
{
    public record CreateDrugCommand(string Name, string Manufacturer, string CountryName) : IRequest<Guid>;
}
