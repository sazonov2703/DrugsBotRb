using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands;

public record CreateDrugStoreCommand(string DrugNetwork, int Number, Address Address) : IRequest<Guid>;