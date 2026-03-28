using MediatR;
using Onion.Application.Common.Results;
using Onion.Application.Logic.Groups.Models;
using Onion.Domain.Models;

namespace Onion.Application.Logic.Groups.GetAll;

public sealed record GetAllGroupsQuery() : IRequest<Result<List<GroupDto>>>;