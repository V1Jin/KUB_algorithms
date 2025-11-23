abstract class Data
{
    public virtual void Add(List<Student> students)
    {
        Console.WriteLine("Введите фамилию");
        string command = Console.ReadLine();
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
    }

    public virtual void Change(List<Student> students)
    {
        Console.WriteLine("Введите фамилию из следующих:\n");
        students.ForEach(el =>
        {
            Console.WriteLine(el.surname);
        });
        string command = Console.ReadLine();
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
    }

    public virtual void Delete(List<Student> students)
    {
        Console.WriteLine("Введите фамилию из следующих:\n");
        students.ForEach(el =>
        {
            Console.WriteLine(el.surname);
        });
        string command = Console.ReadLine();
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
    }

    public virtual void Print(List<Student> students)
    {
        students.ForEach(el =>
        {
            Console.WriteLine(el.surname + " группа: " + el.group + " " + el.institute.name + " " + el.PrintSubjects());
        });
    }

    public virtual void Response1(List<Student> students)
    {
        Dictionary<string, int> instituteExcellentCount = new Dictionary<string, int>();

        students.ForEach(student =>
        {
            if (student.IsExcellent())
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

        string currentDirectory = GetCurrentDirectory();

        using (StreamWriter fstream = new StreamWriter($@"{currentDirectory}\result.txt"))
        {
            if (maxInstitute != "") fstream.Write($"Институт с наибольшим количеством отличников: {maxInstitute} = {maxExcellentStudents} отличник(ов)");
            else fstream.Write($"0 отличников в каждом из институтов :( ");
        }

    }

    public virtual string GetCurrentDirectory()
    {
        return Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString();
    }

    public virtual void GetAvg(List<Student> students)
    {
        Console.WriteLine("Введите фамилию из следующих:\n");
        students.ForEach(el =>
        {
            Console.WriteLine(el.surname);
        });
        string command = Console.ReadLine();
        bool isFound = false;
        students.ForEach(el =>
        {
            if (command == el.surname)
            {
                el.AvgMark();
                isFound = true;
                return;
            }
        });
        if (!isFound) Console.WriteLine("Студент не найден");
    }

    public virtual void RegisterDelegate(List<Student> students)
    {
        students.ForEach(el =>
        {
            el.RegisterDelegate(bluePrint);
            el.RegisterDelegate(YellowPrint);
            el.RegisterDelegate(MagentaPrint);
            el.RegisterDelegate(Log);
        });
        Console.WriteLine("OK!");
    }

    // For delegate
    public virtual void bluePrint(string str)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public virtual void YellowPrint(string str)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public virtual void MagentaPrint(string str)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    public virtual void Log(string str)
    {
        using (StreamWriter file = new StreamWriter($@"{GetCurrentDirectory()}\log.txt", true))
        {
            file.WriteLine(str);
        }
    }

}
