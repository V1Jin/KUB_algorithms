using System.Drawing;

public class tensor
{
    private int last_index = 0;
    private int[,] arr;
    private int size;

    public tensor(int size)
    {
        arr = new int[size, size];
        this.size = size;
    }

    public void addVector(vector x)
    {
        for (int i = 0; i < x.size; i++)
        {
            arr[last_index, i] = x[i];
        }
        last_index++;
    }

    private bool isSymmetric()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (arr[i, j] != arr[j, i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public double lenVector(vector x)
    {
        if (isSymmetric())
        {
            vector temp = new vector(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    temp[i] += x[j] * arr[j, i];
                }
            }

            temp.print();

            double length = 0;
            for (int i = 0; i < size; i++)
            {
                length += temp[i] * x[i];
            }
            length = Math.Sqrt(length);

            return length;
        }
        else
        {
            Console.WriteLine("Ошибка, матрица не симметрична");
            return 0;
        }
    }

    public void print()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public override string ToString()
    {
        return "Hello";
    }
}