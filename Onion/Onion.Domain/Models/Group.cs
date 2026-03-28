namespace Onion.Domain.Models;

public class Group : ModelBase<Guid>
{
    public string Name { get; set; }
    public int Course { get; set; }
    public int StudentsCount { get; set; }

    public Group()
    {
        Id = Guid.NewGuid();
    }

    public Group(string name, int course, int studentsCount)
    {
        Id = Guid.NewGuid();
        Name = name;
        Course = course;
        StudentsCount = studentsCount;
    }

    public void TransferToNextCourse()
    {
        Course++;
    }
}