using System;

namespace stacc_class
{
    class Program
    {
        class CustomStacc
        {
            private int[] innerArray;
            public int Count { get; private set; } = 0;
            private int DefaultSize = 8;

            public CustomStacc()
            {
                innerArray = new int[DefaultSize];
            }

            public CustomStacc(int CustomSize)
            {
                innerArray = new int[CustomSize];
            }

            public void Push(int element)
            {
                while (Count >= innerArray.Length) Double();
                innerArray[Count] = element;
                Count++;
            }

            public int Peek()
            {
                return innerArray[Count-1];
            }

            public int Pop()
            {
                int popped = innerArray[Count-1];
                innerArray[Count - 1] = 0;
                Count--;
                if (Count < innerArray.Length / 2 && innerArray.Length/2>=DefaultSize) Halve();
                return popped;
            }

            public void ForEach(Action<object> action)
            {
                for (int i = 0; i < Count; i++) action(innerArray[i]);
            }

            #region private

            private void Double()
            {
                int[] temparray = new int[innerArray.Length * 2];
                innerArray.CopyTo(temparray, 0);
                innerArray = temparray;
            }

            private void Halve()
            {
                int[] temparray = new int[innerArray.Length / 2];
                for (int i = 0; i < innerArray.Length / 2; i++) temparray[i] = innerArray[i];
                innerArray = temparray;
            }

            #endregion


        }
        static void Main(string[] args)
        {
            CustomStacc woo = new CustomStacc();
            for (int i = 1; i <= 13; i++) woo.Push(i);
            Console.WriteLine(woo.Peek());
            for (int i = 0; i < 7; i++) woo.Pop();
            Console.WriteLine(woo.Peek());
        }
    }
}
