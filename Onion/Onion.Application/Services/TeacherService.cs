using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Application.Services.Interfaces;
using Onion.Domain.Models;

namespace Onion.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly IApplicationDbContext _dbContext;

    public TeacherService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(string firstName, string lastName, CancellationToken cancellationToken)
    {
        // валидация

        var teacher = new Teacher(firstName, lastName);
        _dbContext.Teachers.Add(teacher);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return teacher.Id;
    }

    public async Task<List<Teacher>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Teachers.AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Teacher?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Teachers.AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
