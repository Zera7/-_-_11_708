using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        TestMergeSort(15);
        Console.Read();
    }

    /// <summary>
    /// ТЕстирует функцию сортировки
    /// </summary>
    /// <param name="len">Количество элементов тестового массива</param>
    public static void TestMergeSort(int len)
    {
        Random rnd = new Random();
        var testArray = new int[len];
        for (int i = 0; i < testArray.Length; i++)
            testArray[i] = rnd.Next(51) - 25;

        MergeSort(testArray);

        foreach (var item in testArray)
            Console.Write(item + " ");
    }

    /// <summary>
    /// Принимает массив для сортировки, вызывает функцию сортировки
    /// </summary>
    /// <param name="input">Сортируемый массив</param>
    public static void MergeSort(int[] input)
    {
        MergeSort(input, 0, input.Length - 1);
    }

    /// <summary>
    /// Рекурсивно разбивает массив на части, потом передает их в Merge
    /// </summary>
    /// <param name="input">Сортируемый массив</param>
    /// <param name="low">Индекс левого элемента подмассива</param>
    /// <param name="high">Индекс правого элемента подмассива</param>
    public static void MergeSort(int[] input, int low, int high)
    {
        if (low < high)
        {
            int middle = (low + high) / 2;
            MergeSort(input, low, middle);
            MergeSort(input, middle + 1, high);
            Merge(input, low, middle, high);
        }
    }

    /// <summary>
    /// Сортирует подмассивы с индексами low .. middle и middle .. high 
    /// </summary>
    /// <param name="input">Сортируемый массив</param>
    /// <param name="low">Индекс первого элемента первого подмассива</param>
    /// <param name="middle">Индекс последнего элемента первого подмассива</param>
    /// <param name="high">Индекс последнего элемента второго подмассива</param>
    private static void Merge(int[] input, int low, int middle, int high)
    {
        int left = low;
        int right = middle + 1;
        int[] tmp = new int[(high - low) + 1];
        int tmpIndex = 0;

        while ((left <= middle) && (right <= high))
        {
            if (input[left] < input[right])
            {
                tmp[tmpIndex] = input[left];
                left++;
            }
            else
            {
                tmp[tmpIndex] = input[right];
                right++;
            }
            tmpIndex++;
        }

        if (left <= middle)
        {
            while (left <= middle)
            {
                tmp[tmpIndex] = input[left];
                left++;
                tmpIndex++;
            }
        }

        if (right <= high)
        {
            while (right <= high)
            {
                tmp[tmpIndex] = input[right];
                right++;
                tmpIndex++;
            }
        }

        for (int i = 0; i < tmp.Length; i++)
            input[low + i] = tmp[i];
    }
}