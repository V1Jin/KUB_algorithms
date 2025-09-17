class Program
{
    static void Main(string[] args)
    {
        Staff.Organization = "Роснефть";
        Engineer one = new Engineer(50, "Vasya", ["cars", "trains", "rockets"]);


        Worker worker_1 = new Worker(15, "Gosha");
        Worker worker_2 = new Worker(25, "Danil");
        Worker worker_3 = new Worker(30, "Goose");
        worker_3.Level = "advanced"; // повышение

        worker_3.person_info();
        worker_2.person_info();

        Administration admin_1 = new Administration(50, "Ludmilla");

        admin_1.person_info();

        Staff.Info_staff();
    }
}