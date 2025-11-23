using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();

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
        print(students);

        Console.WriteLine("\n1.Добавить студента\n2.Изменить студента\n3.Удалить студента\n4.Список студентов\n5.Институт с наибольшим количеством отличников\nq.Выход\n");

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "q" || command == "Q") break;

            switch (command)
            {
                case "1":
                    Console.WriteLine("Введите фамилию");
                    command = Console.ReadLine();
                    string surname = command;

                    Console.WriteLine("Введите Вуз");
                    command = Console.ReadLine();
                    string university = command;
                    
                    Console.WriteLine("Введите группу");
                    command = Console.ReadLine();
                    string group = command;
                    int year = int.Parse(group[0].ToString());
                    
                    
                    Console.WriteLine("Введите количество предметов");
                    command = Console.ReadLine();
                    int subjectsCount = int.Parse(command);
                    Console.WriteLine("Введите предмет, кафедру, оценку в строку через пробел:");
                    List<Subject> subjects = new List<Subject>();

                    for (int i = 0; i < subjectsCount; i++)
                    {
                        Subject temp = new Subject();
                        string[] commands = Console.ReadLine().Split(" ");
                        string name = commands[0];
                        string department = commands[1];
                        int mark = int.Parse(commands[2]);

                        temp.Name = name;
                        temp.Department = department;
                        temp.Mark = mark;

                        subjects.Add(temp);
                    }

                    students.Add(new Student(surname, int.Parse(group), year, subjects, new Institute(university)));
                    Console.WriteLine("OK!"); 
                    break;
                case "2":
                    Console.WriteLine("Введите фамилию из следующих:\n");
                    students.ForEach(el =>
                    {
                        Console.WriteLine(el.surname);
                    });
                    command = Console.ReadLine();
                    bool isFound = false;
                    students.ForEach(el =>
                    {
                        if (command == el.surname)
                        {
                            el.Change();
                            isFound = true;
                            return;
                        }
                    });
                    if (!isFound) Console.WriteLine("Студент не найден");
                    break;
                case "3":
                    Console.WriteLine("Введите фамилию из следующих:\n");
                    students.ForEach(el =>
                    {
                        Console.WriteLine(el.surname);
                    });
                    command = Console.ReadLine();
                    Student studentToRemove = null;
                    bool studentFound = false;

                    for (int i = 0; i < students.Count; i++)
                    {
                        if (command == students[i].surname)
                        {
                            studentToRemove = students[i];
                            studentFound = true;
                            break;
                        }
                    }
                    if (studentFound)
                    {
                        students.Remove(studentToRemove);
                        Console.WriteLine("OK!");
                    } 
                    else Console.WriteLine("Ошибка, студент не найден");
                    break;
                case "4":
                    print(students);
                    break;
                case "5":
                    response1(students);
                    break;
                default:
                    Console.WriteLine("Неверная команда");
                    break;
            }
        }



    }



    public static void print(List<Student> students)
    {
        students.ForEach(el =>
        {
            Console.WriteLine(el.surname + " группа: " + el.group + " " + el.institute.name + " " + el.PrintSubjects());
        });
    }
    
    public static void response1(List<Student> students)
    {
        Dictionary<string, int> instituteExcellentCount = new Dictionary<string, int>();

        students.ForEach(student =>
        {
            if (student.isExcellent())
            {
                string instituteName = student.institute.name;
                if (instituteExcellentCount.ContainsKey(instituteName))
                {
                    instituteExcellentCount[instituteName]++;
                }
                else
                {
                    instituteExcellentCount[instituteName] = 1;
                }
            }
        });

        string maxInstitute = "";
        int maxExcellentStudents = 0;

        foreach (var kvp in instituteExcellentCount)
        {
            if (kvp.Value > maxExcellentStudents)
            {
                maxExcellentStudents = kvp.Value;
                maxInstitute = kvp.Key;
            }
        }

        string currentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString();

        using (StreamWriter fstream = new StreamWriter($@"{currentDirectory}\result.txt"))
        {
            if (maxInstitute != "") fstream.Write($"Институт с наибольшим количеством отличников: {maxInstitute} = {maxExcellentStudents} отличник(ов)");
            else fstream.Write($"0 отличников в каждом из институтов :( ");
        }
        
    }
}