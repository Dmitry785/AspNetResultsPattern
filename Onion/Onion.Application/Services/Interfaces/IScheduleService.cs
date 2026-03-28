using Onion.Domain.Models;

namespace Onion.Application.Services.Interfaces;

public interface IScheduleService
{
    Task<List<Schedule>> GetAll(CancellationToken cancellationToken);
    Task<Schedule?> GetById(Guid id, CancellationToken cancellationToken);
    Task<Guid> Create(DateTime date, Guid groupId, Guid teacherId, string subject, CancellationToken cancellationToken);
    Task ChangeTeacher(Guid scheduleId, Guid teacherId, CancellationToken cancellationToken);
}
