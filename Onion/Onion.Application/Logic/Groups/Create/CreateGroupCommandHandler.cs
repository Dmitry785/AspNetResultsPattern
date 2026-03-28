using MediatR;
using Microsoft.Extensions.Logging;
using Onion.Application.Common.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Models;

namespace Onion.Application.Logic.Groups.Create;

public class CreateGroupCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateGroupCommandHandler> logger) 
    : IRequestHandler<CreateGroupCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        //валидация
        if (request.StudentsCount <= 0)
        {
            logger.LogWarning("Группа [{GroupName}]. Недопустимое кол-во студентов [{StudentsCount}]", request.GroupName, request.StudentsCount);
            return Result<Guid>.Fail($"Группа [{request.GroupName}]. Недопустимое кол-во студентов [{request.StudentsCount}]");
        }

        var group = new Group(request.GroupName, 1, request.StudentsCount);
        dbContext.Groups.Add(group);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok(group.Id);
    }
}
