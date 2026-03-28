using MediatR;
using Onion.Application.Common.Results;

namespace Onion.Application.Logic.Groups.Create;

public sealed record CreateGroupCommand(string GroupName, int StudentsCount) 
    : IRequest<Result<Guid>>;
