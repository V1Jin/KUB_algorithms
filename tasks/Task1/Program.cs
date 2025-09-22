using System;

class Program
{
    static void Main()
    {
        string path = "D:/c# prog/tasks/Task1/vectors";
        using StreamReader file = new StreamReader(path);

        int size = int.Parse(file.ReadLine());
        vector Vector = new vector(size);

        tensor matrix = new tensor(size);

        int[] tempVector = Array.ConvertAll(file.ReadLine().Split(' '), int.Parse);
        for (int i = 0; i < tempVector.Length; i++)
        {
            Vector.add(tempVector[i]);
        }
        Vector.print();
        Console.WriteLine();

        vector temp = new vector(size);
        for (int i = 0; i < size; i++)
        {
            tempVector = Array.ConvertAll(file.ReadLine().Split(' '), int.Parse);
            temp.Arr = tempVector;
            matrix.addVector(temp);
        }

        matrix.print();

        Console.WriteLine("длина вектора x в заданном пространстве = " + matrix.lenVector(Vector));
        
    }
}

