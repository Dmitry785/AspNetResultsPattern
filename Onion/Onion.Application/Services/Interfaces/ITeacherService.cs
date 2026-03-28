using Onion.Domain.Models;

namespace Onion.Application.Services.Interfaces;

public interface ITeacherService
{
    Task<List<Teacher>> GetAll(CancellationToken cancellationToken);
    Task<Teacher?> GetById(Guid id, CancellationToken cancellationToken);
    Task<Guid> Create(string firstName, string lastName, CancellationToken cancellationToken);
}
