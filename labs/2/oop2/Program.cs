class Program
{
    static void Main(string[] args)
    {
        Staff.Organization = "Роснефть";
        Engineer one = new Engineer(50, "Vasya", ["cars", "trains", "rockets"]);


        var Owner = new { Salary = 300000, Name = "Kolya",    };

        Worker worker_Vasya = new Worker(15, "Gosha");
        Worker worker_Danil = new Worker(25, "Danil");
        Worker worker_Goose = new Worker(30, "Goose");
        worker_Vasya.Level = "advanced"; // повышение

        worker_Vasya.person_info();
        worker_Danil.person_info();

        Administration admin_1 = new Administration(50, "Ludmilla");

        admin_1.person_info();



    }
}