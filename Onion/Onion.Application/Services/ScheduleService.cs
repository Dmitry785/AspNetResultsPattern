using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Application.Services.Interfaces;
using Onion.Domain.Models;

namespace Onion.Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IApplicationDbContext _dbContext;

    public ScheduleService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeTeacher(Guid scheduleId, Guid teacherId, CancellationToken cancellationToken)
    {
        var schedule = await _dbContext.Schedules
            .Where(x => x.Id == scheduleId)
            .FirstOrDefaultAsync(cancellationToken);
        if (schedule == null)
            return;

        var teacher = await _dbContext.Teachers.AsNoTracking()
            .Where(x => x.Id == teacherId)
            .FirstOrDefaultAsync(cancellationToken);
        if (teacher == null)
            return;

        schedule.TeacherId = teacherId;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Guid> Create(DateTime date, Guid groupId, Guid teacherId, string subject, CancellationToken cancellationToken)
    {
        //TODO: валидация
        var group = await _dbContext.Groups.AsNoTracking()
            .Where(x => x.Id == groupId)
            .FirstOrDefaultAsync(cancellationToken);
        if (group == null)
        {
            return Guid.Empty;
        }

        var schedule = new Schedule(group.Id, teacherId, date, subject);
        _dbContext.Schedules.Add(schedule);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return schedule.Id;
    }

    public async Task<List<Schedule>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Schedules.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Schedule?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Schedules.AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
