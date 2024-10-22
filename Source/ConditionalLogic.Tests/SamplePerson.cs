namespace ConditionalLogic.Tests;

public class SamplePerson
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IList<int> Values { get; set; } = new List<int>();
}