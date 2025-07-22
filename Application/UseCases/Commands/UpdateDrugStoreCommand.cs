using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands;

public record UpdateDrugStoreCommand(string Name, string NewDrugNetwork, int NewNumber, string City, string Street, string House) : IRequest<Guid>;
