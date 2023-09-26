using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Models;

namespace Lab_3.Logic
{
    internal static class Selector
    {
        private static readonly Random Rnd = new Random(); 
        public static string SelectKey(Student st)
        {
            return (Rnd.Next() + st.GetHashCode()).GetHashCode().ToString() ;
        }
    }
}

