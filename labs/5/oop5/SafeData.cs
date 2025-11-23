class SafeData : Data
{
    public event EventHandler<string> Error;

    protected virtual void ErrorOccurred(string message)
    {
        Error?.Invoke(this, message);
    }


    public override void Add(List<Student> students)
    {
        try
        {
            base.Add(students);
        }
        catch (Exception ex) 
        {
            ErrorOccurred($"Ошибка в Add, {ex.GetType()}");
        }

    }

    public override void Change(List<Student> students)
    {
        try
        {
            base.Change(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в Change, {ex.GetType()}"); 
        }

    }

    public override void Delete(List<Student> students)
    {
        try
        {
            base.Delete(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в Delete, {ex.GetType()}"); 
        }

    }

    public override void Response1(List<Student> students)
    {
        try
        {
            base.Response1(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в Response, {ex.GetType()}"); 
        }

    }

    public override void GetAvg(List<Student> students)
    {
        try
        {
            base.GetAvg(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в GetAvg, {ex.GetType()}"); 
        }

    }

    public override void RegisterDelegate(List<Student> students)
    {
        try
        {
            base.RegisterDelegate(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в Register, {ex.GetType()}"); 
        }

    }

    public override void Print(List<Student> students)
    {
        try
        {
            base.Print(students);
        }
        catch (Exception ex)
        {
            ErrorOccurred($"Ошибка в Register, {ex.GetType()}"); 
        }

    }
}