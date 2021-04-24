using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX5
{
    class GenericList<T>
    {
        T [] arrays;
        private int count;
        private int capacity;
        public GenericList(int size)
        {
            arrays = new T[size];
            //Array.Resize<T>(ref arrays, size);
            capacity = arrays.Length;
            count = 0;

        }

        public void Add(T item)
        {
            
            for (int i = 0; i < arrays.Length; i++)
            {
                if(arrays[i] == null)
                {
                    arrays[i] = item;
                    break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder a = new StringBuilder();
            foreach (var b in arrays)
            {
                if (b != null)
                a.Append($"{b}\n");
            }
            return a.ToString();
        }
        public T this[int index]
        {
            get { return arrays[index]; }
            set { arrays[index] = value; }
        }

    }
}
