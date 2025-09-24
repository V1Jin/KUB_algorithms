class Engineer : Staff
{
    private List<string> skills;

    public Engineer(int age, string name, List<string> skills)
    {
        make(90000, age, name);
        this.skills = skills;
        this.post = "Инженер \n" + "Навыки: " + skills;
    }

    public override void make(int salary, int age, string name)
    {
        this.salary = salary;
        this.age = age;
        this.name = name;
    }
}