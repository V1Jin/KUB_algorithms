public class Student : IStudentInfo, IExcellentStudent
{
    public List<Subject> subjects;
    public Institute institute;
    public string surname = "";
    public int group = 0;
    public int year = 0;
    public delegate void del(string str);
    del studentDel;

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
        if (studentDel != null) studentDel($"{surname}: средняя оцена = {sum / subjects.Count}");
        return (sum / subjects.Count);
    }

    public bool IsExcellent()
    {
        foreach (Subject i in subjects)
        {
            if (i.Mark != 5)
            {
                if (studentDel != null) studentDel($"{surname}: Не отличник!");
                return false;
            }
        }
        if (studentDel != null) studentDel($"{surname}: Отличник!");
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
                if (studentDel != null) studentDel($"{surname}: Изменена фамилия на {command}");
                this.surname = command;
                break;
            case "2":
                Console.WriteLine("Введите новую Группу");
                command = Console.ReadLine();
                if (studentDel != null) studentDel($"{surname}: Изменена группа на {command}");
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

                        if (studentDel != null) studentDel($"{surname}: Изменена оценка по {el.Name} на {command}");
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

    public string GetInfo()
    {
        return $"{surname} группа: {group} {institute.name} {PrintSubjects()}";
    }
    
    public void RegisterDelegate(del method)
    {
        studentDel += method;
    }
}