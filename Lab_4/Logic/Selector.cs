using Lab_4.Models;

namespace Lab_4.Logic
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

