using System.Reflection.Metadata;
using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries
{
    /// <summary>
    /// Обработчик запроса GetDrugByIdQuery.
    /// Возвращает лекарство по его айди.
    /// DI через primary конструктор.
    /// </summary>
    public class GetQueryByIdQueryHandler(IDrugReadRepository drugReadRepository) : IRequestHandler<GetDrugByIdQuery, Drug>
    {
        public async Task<Drug> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
        {
            return await drugReadRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
