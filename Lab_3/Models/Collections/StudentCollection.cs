using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Delegates;
using Microsoft.Win32.SafeHandles;

namespace Lab_3.Models.Collections
{
    internal class StudentCollection<TKey>
    {
        private readonly Dictionary<TKey, Student> students;
        private readonly KeySelector<TKey> selector;

        public StudentCollection(KeySelector<TKey> selector)
        {
            this.students = new Dictionary<TKey, Student>();
            this.selector = selector;
        }

        public double MaxAverageMark
        {
            get
            {
                if (this.students.Count == 0)
                {
                    return default;
                }

                return this.students.Max(st => st.Value.Tests.Count);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> GetStudentsWithEducation(Education education)
        {
            return this.students.Where(st => st.Value.Education == education);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation()
        {
            return this.students.GroupBy(st => st.Value.Education);
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                Student student = new Student();
                this.students.Add(this.selector(student), student);
            }
        }

        public void AddStudents(Student[] students)
        {
            foreach (Student student in students)
            {
                this.students.Add(this.selector(student), student);
            }
        }

        public override string ToString()
        {
            return this.students.Aggregate("", (current, keyValuePair) => 
                current + keyValuePair.Value.ToString() + "\n");
        }

        public string ToShortString()
        {
            return this.students.Aggregate("", (current, keyValuePair) =>
                current + keyValuePair.Value.ToShortString() + 
                $"TestsNumber: {keyValuePair.Value.Tests.Count}" +
                $"ExamsNumber: {keyValuePair.Value.Exams.Count}" + "\n");
        }
    }
}
