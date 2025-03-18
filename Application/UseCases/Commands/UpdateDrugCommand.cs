using Domain.Entities;
using MediatR;

public record UpdateDrugCommand(string Name, string NewName, string NewManufacturer, string NewCountryName) : IRequest<Guid>;
