using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands;

public record CreateDrugStoreCommand(string DrugNetwork, int Number, string City, string Street, string House) : IRequest<Guid>;