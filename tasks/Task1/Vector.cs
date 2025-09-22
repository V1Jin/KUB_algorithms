using System.ComponentModel;

public class vector
{
    public int size { get; set; }
    public int[] arr;
    private int last_index = 0;

    public vector(int size)
    {
        arr = new int[size];
        this.size = size;
    }

    public int[] Arr
    {
        set
        {
            arr = value;
        }
    }

    public int this[int index]
    {
        get
        {
            return arr[index];
        }
        set
        {
            arr[index] = value;
        }
    }

    public void add(int x)
    {
        arr[last_index] = x;
        last_index++;
    }

    public void print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}