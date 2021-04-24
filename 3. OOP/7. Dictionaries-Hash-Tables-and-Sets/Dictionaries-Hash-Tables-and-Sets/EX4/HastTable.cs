using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX4
{
    class HastTable<K, T>
    {
        LinkedList<KeyValuePair<K, T>>[] kvp = new LinkedList<KeyValuePair<K,T>>[16];




        public T,K Add(K k, T t)
        {
            kvp[0] = k,t;
        }


    }
}
