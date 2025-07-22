using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands;

public record CreateDrugItemCommand(string DrugName, string DrugStoreName, decimal Cost, int Count) : IRequest<Guid>;