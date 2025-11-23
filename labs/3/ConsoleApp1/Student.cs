public class Student
{
    public List<Subject> subjects;
    public Institute institute;
    public string surname = "";
    public int group = 0;
    public int year = 0;

    public Student(string surname, int group, int year, List<Subject> subjects, Institute institute)
    {
        this.surname = surname;
        this.subjects = subjects;
        this.group = group;
        this.year = year;

        this.subjects = subjects;
        this.institute = institute; 

    }

    public double AvgMark()
    {
        int sum = 0;
        subjects.ForEach(el => sum += el.Mark);
        return (sum / subjects.Count);
    }

    public bool isExcellent()
    {
        foreach (Subject i in subjects)
        {
            if (i.Mark != 5) return false;
        }
        return true;
    }

    public void Change()
    {
        Console.WriteLine("Что менять?");
        Console.WriteLine("""
        -----------------
        1.Фамилия
        2.Группа
        3.Курс
        4.Оценка по предмету
        q, Q - Выход
        -----------------
        """);
        string command = Console.ReadLine();
        if (command == "q" || command == "Q") return;
        switch (command)
        {
            case "1":
                Console.WriteLine("Введите новую фамилию");
                command = Console.ReadLine();
                this.surname = command;
                break;
            case "2":
                Console.WriteLine("Введите новую Группу");
                command = Console.ReadLine();
                this.group = int.Parse(command);
                break;
            case "3":
                Console.WriteLine("Введите новый курс");
                command = Console.ReadLine();
                this.year = int.Parse(command);
                break;
            case "4":
                Console.WriteLine("Введите предмет из перечисленных:\n");
                subjects.ForEach(el =>
                {
                    Console.WriteLine(el.Name);
                });
                command = Console.ReadLine();

                bool subjectExist = false;
                subjects.ForEach(el =>
                {
                    if (el.Name == command)
                    {
                        subjectExist = true;
                        Console.WriteLine("Введите оценку:");
                        command = Console.ReadLine();

                        el.Mark = int.Parse(command);
                    }
                });
                if (subjectExist == false) Console.WriteLine("Предмет не найден");
                break;
            default:
                Console.WriteLine("Ошибка");
                break;
        }
        Console.WriteLine("ОК!");
    }
    
    public string PrintSubjects()
    {
        string str = "";
        subjects.ForEach(el =>
        {
            str += el.Name + " = " + el.Mark + " ";
        });
        return str;
    }

}