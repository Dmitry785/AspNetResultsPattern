namespace Onion.Application.Logic.Groups.Models;

public class GroupFullDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Course { get; set; }
    public int StudentsCount { get; set; }
}