namespace Onion.Domain.Models;

public class Teacher : ModelBase<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Teacher()
    {
        Id = Guid.NewGuid();
    }

    public Teacher(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
}
