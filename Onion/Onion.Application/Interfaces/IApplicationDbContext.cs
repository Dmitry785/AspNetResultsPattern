using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;

namespace Onion.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Group> Groups { get; set; }
    DbSet<Teacher> Teachers { get; set; }
    DbSet<Schedule> Schedules { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
