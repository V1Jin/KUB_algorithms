using System.Diagnostics.Tracing;
using System.Dynamic;
using Microsoft.Win32.SafeHandles;

public class Staff
{
    private static int staff_count;
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

    public Staff(int salary, int age, string name)
    {
        if (age > 18)
        {
            this.salary = salary;
            work_experience = 0;
            staff_count++;
            this.name = name;
            sum_ages += age;
            this.age = age;
            Console.WriteLine("{0} Успешно нанят", name);
        }
        else Console.WriteLine("Возраст не соотв. требованиям для {0}", name);
    }

    public static void Info_staff()
    {
        int sr = sum_ages / staff_count;
        Console.WriteLine("\nИНФО ОРГАНИЗАЦИИ \n Организация = {0} \n В Штате = {1} чел.\n Средний возраст = {2} лет \n----------\n", organization, staff_count, sr);
    }

    public void person_info()
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