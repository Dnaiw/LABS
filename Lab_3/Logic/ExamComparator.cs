using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Models;
using Lab_3.Models;

namespace Lab_3.Logic
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
