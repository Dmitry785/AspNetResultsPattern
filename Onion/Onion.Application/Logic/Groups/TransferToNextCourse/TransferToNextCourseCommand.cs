using MediatR;

namespace Onion.Application.Logic.Groups.TransferToNextCourse;

public sealed record TransferToNextCourseCommand(Guid GroupId) : IRequest;
