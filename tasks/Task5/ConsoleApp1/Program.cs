class Program
{
    public static void Main()
    {
        int[] a = { 1, 15, 3, 60, 40, 24, 50, 51 };
        for (int i = 0; i < a.Length; i++ ) Console.Write($"{a[i]} ");
        Console.WriteLine();
        Console.WriteLine("min heap:");
        Heap hipka_min = new Heap(a, true);
        hipka_min.Print();
        Console.WriteLine("max heap:");
        int[] b = { 50,100, 20, 22, 13, 1, 5, 6, 102 };
        Heap hipka_max = new Heap(b, false);
        hipka_max.Print();

        Console.WriteLine("Извлекаем макс корень: ");
        Console.Write(hipka_max.ExtractRoot() + " \n");
        hipka_max.Print();


        Console.WriteLine("Меняем второй элемент на 2:");
        hipka_max.ChangeKey(1, 2);
        hipka_max.Print();

        Console.WriteLine("Объединяем кучи:");
        hipka_min.Merge(hipka_max);
        hipka_min.Print();

        Console.WriteLine("Добавляем 2 элемента: 25 и 30");
        hipka_min.Add(25);
        hipka_min.Add(30);

        hipka_min.Print();



    }
}