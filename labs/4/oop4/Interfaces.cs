public interface IStudentInfo
{
    string GetInfo();
    double AvgMark();
}

public interface IExcellentStudent
{
    bool IsExcellent();
}

public interface IName
{
    public string Name { get; set; }
    public string Department { get; set; }
}