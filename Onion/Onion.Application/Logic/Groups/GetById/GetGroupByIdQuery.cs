using MediatR;
using Onion.Application.Common.Results;
using Onion.Application.Logic.Groups.Models;

namespace Onion.Application.Logic.Groups.GetById;

public sealed record GetGroupByIdQuery(Guid Id) : IRequest<Result<GroupFullDto>>;