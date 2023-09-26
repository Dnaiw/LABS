using Lab_5.Models;

namespace Lab_5.Logic
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

