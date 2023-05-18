using System;

namespace Program
{
    public class MyArray
    {
        private double [] data;

        public MyArray()
        {
            data = new double[0];
        }

        public MyArray(int size)
        {
            data = new double[size];
        }


        // populate array with random values
        public void populate(int size)
        {
            var rand = new Random();

            if(data.Length != size)
            {
                Array.Resize<double>(ref data, size);
            }

            for(int i = 0; i < data.Length; i++)
            {
                data[i] = rand.NextDouble();
            }
        }

        // print first n elements of array
        // negative n => print all elements
        public void print(int n = -1)
        {
            if(n < 0 || n > data.Length)
            {
                n = data.Length;
            }

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, data[i]);
            }
        }

        // sort data using insertion method
        public void insertSort()
        {
            // pointer to the start of the unsorted section of the array
            int ptr = 1;
            

            for( ; ptr < data.Length; ptr++)
            {
                // find where to insert data[ptr] into the sorted section
                int insertBefore = ptr;
                for(int i = 0; i < ptr; i++)
                {
                    if(data[ptr] < data[i])
                    {
                        insertBefore = i;
                        break;
                    }
                }
                // (if insertBefore is equal to ptr, then don't need to do anything)

                if(insertBefore < ptr)
                {
                    double tmp = data[ptr];
                    for(int i = ptr; i > insertBefore; i--)
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
            for(int i = 0; i < data.Length - 1; i++)
            {
                if(data[i] > data[i+1])
                {
                    Console.WriteLine("NOT SORTED!");
                    Console.WriteLine("arr[{0}] = {1}", i, data[i]);
                    Console.WriteLine("arr[{0}] = {1}", i + 1, data[i+1]);
                    return;
                }
            }

            Console.WriteLine("SORTED!");

        }

        private int setPivot(int left, int right)
        {
            double pivot = data[right];
            int pivotIndex = left;

            for(int i = left; i < right; i++)
            {
                if(data[i] < pivot)
                {
                    double tmp = data[i];
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
            if(left >= right)
            {
                return;
            }
            int pivot = setPivot(left, right);
            qSortHelper(left, pivot - 1);
            qSortHelper(pivot + 1, right);
        }





        
    }
}