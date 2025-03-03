using System;

namespace ConsoleApp1
{
    public class Sorter
    {
        public static int[] ShellSort(int[] array)
        {
            int length = array.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i++)
                {
                    int temp = array[i];
                    int j = i;
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                }
            }
            return array;
        }

        public static int[] ImprovedBubbleSortReverse(int[] array)
        {
            int length = array.Length;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i < length - 1; i++)
                {
                    // Сравниваем и меняем местами, если текущий элемент меньше следующего
                    if (array[i] < array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        swapped = true;
                    }
                }
                // уменьшить длину на 1, так как последний элемент уже на месте
                length--;
            } while (swapped);

            return array;
        }

        public static int[] CombSort(int[] array)
        {
            int currentStep = array.Length - 1;
            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }
            InsertionSort(array);
            return array;
        }

        private static void InsertionSort(int[] array)
        {
            int length = array.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i++)
                {
                    int temp = array[i];
                    int j = i;
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                }
            }
        }

        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        private static void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public static string PrintArray(int[] array)
        {
            return string.Join(" ", array);
        }

        public static void Main(string[] args)
        {
            int[] sampleArray = { 5, 3, 8, 4, 2, 23, 10, 43, 42, 22, 10 };

            Console.WriteLine("Входной массив: " + PrintArray(sampleArray));

            int[] sortedArrayComb = CombSort((int[])sampleArray.Clone());
            Console.WriteLine("Сортировка комбинированием: " + PrintArray(sortedArrayComb));

            int[] sortedArrayShell = ShellSort((int[])sampleArray.Clone());
            Console.WriteLine("Сортировка Шелла: " + PrintArray(sortedArrayShell));

            int[] sortedArrayBubble = ImprovedBubbleSortReverse((int[])sampleArray.Clone());
            Console.WriteLine("Сортировка пузырьком: " + PrintArray(sortedArrayBubble));
        }
    }
}