class Administration : Staff
{

    public int Department { get; set; }
    public Administration(int age, string name)
    {
        make(150000, age, name);
        Random dep = new Random();
        Department = dep.Next(10);
        this.post = "Администрация, " + Department + " отдел";
    }

    public override void make(int salary, int age, string name)
    {
        this.salary = salary;
        this.age = age;
        this.name = name;
    }
}