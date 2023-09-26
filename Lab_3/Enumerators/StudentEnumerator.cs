using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Models;

namespace Lab_3.Enumerators
{
    internal class StudentEnumerator: IEnumerator
    {
        private string[] works;
        private int position;
        public StudentEnumerator(Student student)
        {
            this.works = new string[student.ExamsAndTests.Count()];
            int i = 0;

            foreach (string name in student.Exams.Cast<Exam>().Select(ex => ex.Name))
            {
                this.works[i] = name;
                i++;
            }

            foreach (string name in student.Tests.Cast<Test>().Select(ex => ex.Name))
            {
                this.works[i] = name;
                i++;
            }

            this.position = -1;
        }

        public bool MoveNext()
        {
            if (position < works.Length)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                if (position == -1 || position >= works.Length)
                    throw new ArgumentException();
                return works[position];
            }
        }
    }
}
