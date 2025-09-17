class Administration : Staff
{

    public int Department { get; set; }
    public Administration(int age, string name)
        : base(100000, age, name)
    {
        Random dep = new Random();
        Department = dep.Next(10);
        this.post = "Администрация, " + Department + " отдел";
    }
}