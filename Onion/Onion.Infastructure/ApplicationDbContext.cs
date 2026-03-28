using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Domain.Models;

namespace Onion.Infastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}