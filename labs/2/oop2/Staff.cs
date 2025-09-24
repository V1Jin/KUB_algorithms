using System.Diagnostics.Tracing;
using System.Dynamic;
using Microsoft.Win32.SafeHandles;

abstract class Staff
{
    protected int staff_count;
    private static int sum_ages;
    private static string organization;
    public int salary;
    public int work_experience;
    protected string post;

    public int age { get; set; }
    public string name { get; set; }
    public static string Organization
    {
        get
        {
            return organization;
        }
        set
        {
            organization = value;
        }
    }

    public abstract void make(int salary, int age, string name);

    public virtual void person_info()
    {
        Console.WriteLine("\nОрганизация = {0}, \nИмя = {1} \nВозраст = {2} \nдолжность = {3} \nзарплата = {4} \n----------\n", organization, name, age, post, salary);
    }

    ~Staff()
    {
        Console.WriteLine("Работник {0} удален", name);
        staff_count--;
        sum_ages -= this.age;
    }
}