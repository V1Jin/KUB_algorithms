class Worker : Staff
{
    private string level;

    public string Level
    {
       get {
            return this.level;
       }
        set
        {
            if (value == "advanced")
            {
                this.level = "advanced";
                this.post = "Повыш. рабочий";
                this.salary += 10000;
            }
            else if (value == "ultra")
            {
                this.level = "ultra";
                this.post = "Высш. рабочий";
                this.salary += 20000;
            }
       } 
    }

    public Worker(int age, string name)
        : base(30000, age, name)
    {
        this.level = "common";
        this.post = "Рабочий";
    }
}