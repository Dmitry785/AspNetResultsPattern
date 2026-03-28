using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onion.Application.Interfaces;

namespace Onion.Application.Logic.Groups.TransferToNextCourse;

public class TransferToNextCourseCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<TransferToNextCourseCommandHandler> logger) : IRequestHandler<TransferToNextCourseCommand>
{
    public async Task Handle(TransferToNextCourseCommand request, CancellationToken cancellationToken)
    {
        var group = await dbContext.Groups
            .Where(x => x.Id == request.GroupId)
            .FirstOrDefaultAsync(cancellationToken);
        if (group == null)
        {
            logger.LogWarning("Группа [{GroupId}] не найдена", request.GroupId);
            throw new ArgumentException($"Группа [{request.GroupId}] не найдена");
        }

        group.TransferToNextCourse();
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
