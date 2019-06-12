using System;

namespace CustomStructures
{
    /// <summary>
    /// Integer List
    /// </summary>
    public class CustomList<T> where T: IComparable
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 2;

        /// <summary>
        /// Internal array
        /// </summary>
        private T[] innerArr;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates custom integer list 
        /// with default size
        /// </summary>
        public CustomList()
        {
            //var t = new T();
            innerArr = new T[defaultSize];
        }

        /// <summary>
        /// Creates custom integer list 
        /// with initial size
        /// </summary>
        /// <param name="initialSize">Initial size 
        /// of the list</param>
        public CustomList(int initialSize)
        {
            innerArr = new T[initialSize];
        }

        /// <summary>
        /// Custom list indexer
        /// </summary>
        /// <param name="index">Index of the element to access</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                CheckIdexRange(index);

                return innerArr[index];
            }
            set
            {
                CheckIdexRange(index);
                innerArr[index] = value;
            }
        }

        /// <summary>
        /// Adds element to the list
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Add(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        /// <summary>
        /// Adds many elements to the list
        /// </summary>
        /// <param name="list">Elements to add</param>
        public void AddRange(T[] list)
        {
            if (list.Length + Count >= innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length * 2)
                {
                    Grow((list.Length + Count) * 2);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }

        /// <summary>
        /// Removes element at position
        /// </summary>
        /// <param name="index">position</param>
        /// <exception cref="IndexOutOfRangeException">The position is out of range</exception>
        public void RemoveAt(int index)
        {
            CheckIdexRange(index);
            ShiftLeft(index);
            Count--;
            Shrink();
        }

        /// <summary>
        /// Inserts element at certain position
        /// </summary>
        /// <param name="index">Position to insert to</param>
        /// <param name="element">Element to insert</param>
        public void InsertAt(int index, T element)
        {
            CheckIdexRange(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        /// <summary>
        /// Whether list contains element
        /// </summary>
        /// <param name="element">Element to check for</param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            bool result = false;

            for (int i = 0; i < Count; i++)
            {
                if (innerArr[i].Equals(element))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Swaps two elements in the list
        /// </summary>
        /// <param name="firstIndex">Index of first element</param>
        /// <param name="secondIndex">Index of second element</param>
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIdexRange(firstIndex);
            CheckIdexRange(secondIndex);
            T tempElement = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;
        }

        /// <summary>
        /// Shrinks the inner array
        /// </summary>
        public void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                T[] tempArr = new T[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        /// <summary>
        /// Iterates through the custom list
        /// </summary>
        /// <param name="action">Action to execute on each element</param>
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }

        #region private

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            T[] tempArr = new T[newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < Count - 1)
            {
                for (int i = position; i < Count - 1; i++)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }

            innerArr[Count - 1] = default;
        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            for (int i = Count - 1; i >= position; i--)
            {
                innerArr[i + 1] = innerArr[i];
            }

            innerArr[position] = default;
        }

        private void CheckIdexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
