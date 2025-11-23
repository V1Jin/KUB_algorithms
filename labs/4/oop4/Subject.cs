public class Subject : IName
{
    public string Name { get; set; }
    public string Department { get; set; }
    public int Mark { get; set; }

    public Subject(string name, string department, int mark)
    {
        Name = name;
        Department = department;
        Mark = mark;
    }

    public Subject()
    {
        Name = "";
        Department = "";
        Mark = 0;
    }
}