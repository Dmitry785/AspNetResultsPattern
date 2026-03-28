using MediatR;
using Microsoft.EntityFrameworkCore;
using Onion.Application.Common.Results;
using Onion.Application.Interfaces;
using Onion.Application.Logic.Groups.Models;

namespace Onion.Application.Logic.Groups.GetAll;

public sealed record GetAllGroupsQueryHandler(
    IApplicationDbContext dbContext) 
    : IRequestHandler<GetAllGroupsQuery, Result<List<GroupDto>>>
{
    public async Task<Result<List<GroupDto>>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
    {
        var groups = await dbContext.Groups.AsNoTracking().ToListAsync(cancellationToken);
        var result = groups.Select(x => new GroupDto()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
        return Result.Ok(result);
    }
}