namespace Onion.Domain.Models;

public class Schedule : ModelBase<Guid>
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public DateTime Date { get; set; }
    public string Subject { get; set; }

    public Schedule()
    {
        Id = Guid.NewGuid();
    }

    public Schedule(Guid groupId, Guid teacherId, DateTime date, string subject)
    {
        GroupId = groupId;
        TeacherId = teacherId;
        Date = date;
        Subject = subject;
    }

    public void SetTeacher(Guid teacherId)
    {
        if (TeacherId != teacherId)
        {
            TeacherId = teacherId;
        }
    }
}