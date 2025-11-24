using System;

public class Heap
{
    private int[] data;
    private int size;
    private bool isMinHeap;

    public Heap(int[] initial, bool minHeap = true)
    {
        data = new int[initial.Length * 2];
        size = initial.Length;
        for (int i = 0; i < initial.Length; i++) data[i] = initial[i];
        data = initial;
        isMinHeap = minHeap;
        Heapify();
    }


    public int Peek()
    {
        if (size == 0) Console.WriteLine("Ошибка! Куча пуста!");
        return data[0];
    }

    public int ExtractRoot()
    {
        if (size == 0) Console.WriteLine("Ошибка! Куча пуста!");
        int root = data[0];
        data[0] = data[size - 1];
        size--;
        SiftDown(0);
        return root;
    }

    public void Add(int value)
    {
        EnsureCapacity(size + 1);
        data[size] = value;
        SiftUp(size);
        size++;
    }

    public void ChangeKey(int index, int newValue)
    {
        if (index < 0 || index >= size) Console.WriteLine("Ошибка! индекс за пределами кучи!");
        int oldValue = data[index];
        data[index] = newValue;
        if (Compare(newValue, oldValue) < 0)
            SiftUp(index);
        else
            SiftDown(index);
    }

    public void Merge(Heap other)
    {
        EnsureCapacity(size + other.size);
        Array.Copy(other.data, 0, data, size, other.size);
        size += other.size;
        Heapify();
    }

    private void Heapify()
    {
        for (int i = size / 2 - 1; i >= 0; i--)
            SiftDown(i);
    }

    private void SiftUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (Compare(data[index], data[parent]) >= 0) break;

            int tmp = data[index];
            data[index] = data[parent];
            data[parent] = tmp;

            index = parent;
        }
    }

    private void SiftDown(int index)
    {
        while (true)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int target = index;
            if (left < size && Compare(data[left], data[target]) < 0) target = left;
            if (right < size && Compare(data[right], data[target]) < 0) target = right;
            if (target == index) break;

            int tmp = data[index];
            data[index] = data[target];
            data[target] = tmp;

            index = target;
        }
    }

    private int Compare(int a, int b)
    {
        return isMinHeap ? a.CompareTo(b) : b.CompareTo(a);
    }

    private void EnsureCapacity(int capacity)
    {
        if (capacity > data.Length)
        {
            int[] newData = new int[data.Length * 2];
            Array.Copy(data, newData, data.Length);
            data = newData;
        }
    }

    public void Print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"{data[i]} ");
        }

        Console.WriteLine();
    }
}
