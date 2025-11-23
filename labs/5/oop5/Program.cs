


class Program
{
    public static void Main()
    {
        SafeData data = new SafeData();
        List<Student> students = new List<Student>();

        data.Error += ErrorMethod;



        students.Add(new Student("Уайт", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 5), new Subject("Физра", "Кафедра спорта", 4), new Subject("КАСД", "Кафедра выч. технологий", 5) }, new Institute("КУБГУ")));
        students.Add(new Student("Пинкман", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 4), new Subject("Физра", "Кафедра спорта", 3), new Subject("КАСД", "Кафедра выч. технологий", 2) }, new Institute("КУБГУ")));
        students.Add(new Student("Чириков", 22, 2, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 3), new Subject("Физра", "Кафедра спорта", 5), new Subject("КАСД", "Кафедра выч. технологий", 5) }, new Institute("КУБГУ")));
        students.Add(new Student("Маслов", 32, 3, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 2), new Subject("Физра", "Кафедра спорта", 5), new Subject("КАСД", "Кафедра выч. технологий", 2) }, new Institute("КУБГУ")));
        students.Add(new Student("Манка", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 2), new Subject("Физра", "Кафедра спорта", 5), new Subject("КАСД", "Кафедра выч. технологий", 4) }, new Institute("КУБГУ")));
        students.Add(new Student("Лукова", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 5), new Subject("Физра", "Кафедра спорта", 2), new Subject("КАСД", "Кафедра выч. технологий", 3) }, new Institute("КУБГТУ")));
        students.Add(new Student("Верблюдов", 32, 3, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 5), new Subject("Физра", "Кафедра спорта", 3), new Subject("КАСД", "Кафедра выч. технологий", 5) }, new Institute("КУБГТУ")));
        students.Add(new Student("Фермов", 32, 3, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 3), new Subject("Физра", "Кафедра спорта", 4), new Subject("КАСД", "Кафедра выч. технологий", 4) }, new Institute("КУБГТУ")));
        students.Add(new Student("Синов", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 4), new Subject("Физра", "Кафедра спорта", 3), new Subject("КАСД", "Кафедра выч. технологий", 4) }, new Institute("КУБГУ")));
        students.Add(new Student("Джонов", 12, 1, new List<Subject>() { new Subject("Матан", "Кафедра выч. технологий", 5), new Subject("Физра", "Кафедра спорта", 4), new Subject("КАСД", "Кафедра выч. технологий", 5) }, new Institute("КУБГУ")));
        data.Print(students);

        Console.WriteLine("\n1.Добавить студента\n2.Изменить студента\n3.Удалить студента\n4.Список студентов\n5.Институт с наибольшим количеством отличников\n6.Регистрация делегатов\n7.Средняя оценка\nq.Выход\n");

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "q" || command == "Q") break;

            switch (command)
            {
                case "1":
                    data.Add(students);
                    break;
                case "2":
                    data.Change(students);
                    break;
                case "3":
                    data.Delete(students);
                    break;
                case "4":
                    data.Print(students);
                    break;
                case "5":
                    data.Response1(students);
                    break;
                case "6":
                    data.RegisterDelegate(students);
                    break;
                case "7":
                    data.GetAvg(students);
                    break;
                default:
                    Console.WriteLine("Неверная команда");
                    break;
            }
        }
    }
    
    public static void ErrorMethod(object sender, string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

}