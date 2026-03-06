using System;
using System.Collections.Generic;
using System.Net.Quic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class GenericRepository<T> where T : ICloneable, IComparable<T>
    {
        private T[] items;
        private int current;
        public GenericRepository(int initialSize)
        {
            if (initialSize < 0) throw new ArgumentException("size cannot be less than zero");
            items = new T[initialSize];
            current = 0;
        }
        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("Item cannot be null");
            if (current == items.Length)
            {
                T[] newItems = new T[items.Length == 0 ? 4 : items.Length * 2];
                for (int i = 0; i < current; i++)
                    newItems[i] = items[i];
                items = newItems;
            }
            items[current++] = item;
        }
        public void Remove(T item)
        {
            if (item == null) throw new ArgumentNullException("Item cannot be null");
            for (int i = 0; i < current; i++)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    for (int j = i; j < current - 1; j++)
                        items[j] = items[j + 1];
                    items[current - 1] = default;
                    current--;
                    break; 
                }
            }
        }
        // bubble sort
        public void Sort()
        {
            for (int i = 0; i < current - 1; i++)
                for (int j = 0; j < current - i - 1; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        T temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
        }
        public T[] GetAll()
        {
            T[] result = new T[current];
            for (int i = 0; i < current; i++)
                result[i] = items[i];
            return result;
        }
    }
}
