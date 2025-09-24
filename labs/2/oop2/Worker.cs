class Worker : Staff
{
    private string level;

    public string Level
    {
        get
        {
            return this.level;
        }
        set
        {
            if (value == "advanced")
            {
                this.level = "advanced";
                this.salary += 10000;
            }
            else if (value == "ultra")
            {
                this.level = "ultra";
                this.salary += 20000;
            }
        }
    }

    public override void make(int salary, int age, string name)
    {
        this.salary = salary;
        this.age = age;
        this.name = name;
    }

    public Worker(int age, string name)
    {
        make(30000, age, name);
        this.level = "common";
        this.post = "Рабочий";
    }


    public override void person_info()
    {
        base.person_info();
        Console.WriteLine($"Это рабочий {this.level} класса");
    }
}