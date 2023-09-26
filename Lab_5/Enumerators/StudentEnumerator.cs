using System.Collections;
using Lab_5.Models;

namespace Lab_5.Enumerators
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
            if (this.position < this.works.Length)
            {
                this.position++;
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
                if (this.position == -1 || this.position >= this.works.Length)
                    throw new ArgumentException();
                return this.works[this.position];
            }
        }
    }
}
