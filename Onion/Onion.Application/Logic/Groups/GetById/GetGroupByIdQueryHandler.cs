using MediatR;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Common.Results;
using Onion.Application.Interfaces;
using Onion.Application.Logic.Groups.Models;
using Onion.Domain.Models;

namespace Onion.Application.Logic.Groups.GetById;

public class GetGroupByIdQueryHandler(
    IApplicationDbContext dbContext) 
    : IRequestHandler<GetGroupByIdQuery, Result<GroupFullDto>>
{
    public async Task<Result<GroupFullDto>> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var group = await dbContext.Groups.AsNoTracking()
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        if (group == null)
            return Result<GroupFullDto>.Fail($"Группа с Id {request.Id} не найдена");

        var result = new GroupFullDto()
        {
            Id = group.Id,
            Name = group.Name,
            Course = group.Course,
            StudentsCount = group.StudentsCount
        };
        return Result.Ok(result);
    }
}
