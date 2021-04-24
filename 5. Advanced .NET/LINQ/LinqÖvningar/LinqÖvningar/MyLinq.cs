﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqÖvningar.SL
{
    public static class MyLinq
    {

        public static int Count<T>(this IEnumerable<T> sequence )
        {
            int count = 0;

            foreach(var s in sequence)
            {
                count++;
            }

            return count;
        }
    }
}
