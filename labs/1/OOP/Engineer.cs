class Engineer : Staff
{
    private List<string> skills;

    public Engineer(int age, string name, List<string> skills)
        : base(50000, age, name)
    {
        this.skills = skills;
        this.post = "Инженер \n" + "Навыки: " + skills;
    }
}