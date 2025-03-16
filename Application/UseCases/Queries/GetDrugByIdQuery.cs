using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries
{
    /// <summary>
    /// Запрос для получения лекарства по его айди.
    /// </summary>
    /// <param name="Id">Айди.</param>
    public record GetDrugByIdQuery(Guid Id) : IRequest<Drug>;
}
