using Lab_4.Models;

namespace Lab_4.Logic
{
    internal class ExamComparator: IComparer<Exam>
    {
        public int Compare(Exam? x, Exam? y)
        {
            if (x.Date > y.Date)
            {
                return 1;
            }

            if (x.Date < y.Date)
            {
                return -1;
            }

            return 0;
        }
    }
}
