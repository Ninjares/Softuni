using System;

namespace Workshop1
{
    class Program
    {
        class mahList
        {
            /// <summary>
            /// Internal array
            /// </summary>
            private int[] internalArray;
            private int defaultSize = 4;

            public int Count { get; private set; } = 0;
            /// <summary>
            /// Default Constructor - size 4;
            /// </summary>
            public mahList()
            {
                internalArray = new int[defaultSize];
            }
            /// <summary>
            /// List with a custom size
            /// </summary>
            /// <param name="size">Number of cells</param>
            public mahList(int size)
            {
                internalArray = new int[size];
            }

            public void Add(int element)
            {
                if (internalArray.Length == Count) Grow();
                internalArray[Count] = element;
                Count++;
            }
            
            public void AddRange(int[] list)
            {
                while (list.Length + Count >= internalArray.Length)
                {
                    Grow();
                }
                for(int i=0; i<list.Length; i++)
                {
                    internalArray[i + Count] = list[i];
                }
                Count += list.Length;

                
            }
            /// <summary>
            /// Removes element at given position
            /// </summary>
            /// <param name="index">position</param>
            /// <exception cref="IndexOutOfRangeException">Outputted when [position] is out of range </exception>
            public void RemoveAt(int index)
            {
                if (index < 0 || index > Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                ShiftLeft(index);
                Count--;
            }
            /// <summary>
            /// Indexator
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                    else
                    return internalArray[index];
                }
                set
                {
                    if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                    else
                        internalArray[index] = value;
                }
            }

            public void InsertAt(int index, int element)
            {
                //CheckindexRange(index)
                ShiftRight(index);
                internalArray[index] = element;
                Count++;

            }

            public bool Contains(int element)
            {
                bool result=false;
                foreach(var item in internalArray)
                {
                    if (item == element) { result = true; break; }
                }
                return result;
            }

            public void Shrink()
            {
                if (internalArray.Length/4 > Count)
                {
                    int[] temparr = new int[internalArray.Length/2];
                    for (int i = 0; i < Count; i++)
                        temparr[i] = internalArray[i];
                    internalArray = temparr;
                }
            }

            public void ForEach(Action<object> action)
            {
                for(int i=0; i<Count; i++)
                {
                    action(internalArray[i]);
                }
            }
            #region private

            private void Grow()
            {
                int[] newarray = new int[2 * internalArray.Length];
                internalArray.CopyTo(newarray, 0);
                /*
                 * for(int i=0; i<internalArray.Length; i++) newarray[i] = internalArray[i];
                 */
                internalArray = newarray;
            }
            private void Grow(int something)
            {
                int[] newarray = new int[2 * internalArray.Length];
                internalArray.CopyTo(newarray, 0);
                internalArray = newarray;
            }

            private void ShiftLeft(int pos)
            {
                if (pos < Count - 1)
                {
                    for (int i = pos; i <= Count; i++) internalArray[i] = internalArray[i + 1];
                }
                else if (true)
                {

                }
            }

            private void ShiftRight(int pos)
            {
                if (internalArray.Length == Count)
                {
                    Grow();
                }
                for (int i = Count - 1; i >= pos; i--)
                {
                    internalArray[i + 1] = internalArray[i];
                }
            }

            #endregion

        }
        static void Main(string[] args)
        {
            mahList wooo = new mahList(5);

            wooo.Add(2);
            wooo.Add(5);
            wooo.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            wooo.RemoveAt(1);
            wooo.InsertAt(1, 9999);
            //wooo.InsertAt(9999, 1);
            
            Console.WriteLine(wooo[0]);
        }
    }
}
