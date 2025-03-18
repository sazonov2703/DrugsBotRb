using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands;

public record UpdateDrugStoreCommand(string Name, string NewDrugNetwork, int NewNumber, Address NewAddress) : IRequest<Guid>;
