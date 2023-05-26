using System;

namespace Program
{
    public class MyArray
    {
        private int[] data;

        public MyArray()
        {
            data = new int[0];
        }

        public MyArray(int size)
        {
            data = new int[size];
        }


        // populate array with random values
        public void populate(int size)
        {
            var rand = new Random();

            if (data.Length != size)
            {
                Array.Resize<int>(ref data, size);
            }

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.Next(-100000, 100000);
            }
        }

        // print first n elements of array
        // negative n => print all elements
        public void print(int n = -1)
        {
            if (n < 0 || n > data.Length)
            {
                n = data.Length;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, data[i]);
            }
        }

        // sort data using insertion method
        public void insertSort()
        {
            // pointer to the start of the unsorted section of the array
            int ptr = 1;


            for (; ptr < data.Length; ptr++)
            {
                // find where to insert data[ptr] into the sorted section
                int insertBefore = ptr;
                for (int i = 0; i < ptr; i++)
                {
                    if (data[ptr] < data[i])
                    {
                        insertBefore = i;
                        break;
                    }
                }
                // (if insertBefore is equal to ptr, then don't need to do anything)

                if (insertBefore < ptr)
                {
                    int tmp = data[ptr];
                    for (int i = ptr; i > insertBefore; i--)
                    {
                        data[i] = data[i - 1];
                    }
                    data[insertBefore] = tmp;
                }


            }

        }

        public void qSort()
        {
            qSortHelper(0, data.Length - 1);
        }



        // check if data[] is sorted
        public void checkSorted()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    Console.WriteLine("NOT SORTED!");
                    Console.WriteLine("arr[{0}] = {1}", i, data[i]);
                    Console.WriteLine("arr[{0}] = {1}", i + 1, data[i + 1]);
                    return;
                }
            }

            Console.WriteLine("SORTED!");

        }

        private int setPivot(int left, int right)
        {
            int pivot = data[right];
            int pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (data[i] < pivot)
                {
                    int tmp = data[i];
                    data[i] = data[pivotIndex];
                    data[pivotIndex] = tmp;
                    pivotIndex++;
                }
            }

            data[right] = data[pivotIndex];
            data[pivotIndex] = pivot;
            return pivotIndex;
        }

        private void qSortHelper(int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pivot = setPivot(left, right);
            qSortHelper(left, pivot - 1);
            qSortHelper(pivot + 1, right);
        }


        public int binarySearch(int value)
        {
            int a = 0;
            int b = data.Length - 1;
            int c;

            while(a <= b)
            {
                c = (a + b) / 2;

                if(data[c] == value)
                {
                    return c;
                }

                if(value > data[c])
                {
                    a = c + 1;
                    continue;
                }

                b = c - 1;
            }

            return -1;
        }

        public int lerpSearch(int value)
        {
            int a = 0;
            int b = data.Length - 1;
            int c;

            while(data[a] < value && data[b] > value)
            {
                

                if(data[a] == data[b]) break;

                c = a + (value - data[a]) * (b - a) / (data[b] - data[a]);
                Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

                if(data[c] == value)
                {
                    return c;
                }

                if(value > data[c])
                {
                    a = c + 1;
                    continue;
                }

                b = c - 1;
            }

            if(data[a] == value)
            {
                return a;
            }
            if(data[b] == value)
            {
                return b;
            }

            return -1;

        }






    }
}