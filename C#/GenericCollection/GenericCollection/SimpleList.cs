using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class SimpleList<T> : IEnumerable<T>
    {
        private const int maxSize = 100;
        private int count;
        public int Length
        {
            get { return count; }
        }
        private T[] items;

        public SimpleList()
        {
            items = new T[maxSize];
            count = 0;
        }

        public SimpleList(int size)
        {
            count = 0;
            if (size <= maxSize)
            {
                items = new T[size];
            }
            else
            {
                Console.WriteLine("Size is more than 100! Created list with 100 elements!");
                items = new T[maxSize];
            }
        }

        public void Add(T item)
        {
            if (count >= items.Length)
                throw new InvalidOperationException("List is full!");
            items[count] = item;
            count++;
        }

        public void Add(T[] arrItems)
        {
            if ((count + arrItems.Length) > items.Length)
                throw new InvalidOperationException("List is full!");
            for (int i = 0; i < arrItems.Length; i++)
            {
                items[count] = arrItems[i];
                count++;
            }
        }

        public T Get(int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }

        public void Set(int index, T value)
        {
            if (index >= count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }

        public void Swap(int firstItemIndex, int secondItemIndex)
        {
            if (firstItemIndex >= count || secondItemIndex >= count)
                throw new IndexOutOfRangeException();
            T temp = items[firstItemIndex];
            items[firstItemIndex] = items[secondItemIndex];
            items[secondItemIndex] = temp;
        }

        public void Clear()
        {
            for(int i = 0; i < items.Length; i++)
            {
                items[i] = default(T);
            }
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
