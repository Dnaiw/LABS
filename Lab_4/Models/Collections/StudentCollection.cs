using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Lab_4.Delegates;
using Lab_4.Models.Events;
using Action = Lab_4.Models.Events.Action;

namespace Lab_4.Models.Collections
{
    public delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args)
        where TKey : notnull;

    internal class StudentCollection<TKey>
    {
        private readonly Dictionary<TKey, Student> students;
        private readonly KeySelector<TKey> selector;

        public string Name { get; set; }

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

        public IEnumerable<KeyValuePair<TKey, Student>> Students
        {
            get { return this.students; }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> GetStudentsWithEducation(Education education)
        {
            return this.students.Where(st => st.Value.Education == education);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation()
        {
            return this.students.GroupBy(st => st.Value.Education);
        }

        private void Add(Student student)
        {
            TKey key = selector(student);
            students.Add(key, student);
            StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(this.Name, Action.Add, nameof(student), key));

            void PropertyChangedHandler(object? sender, PropertyChangedEventArgs args)
            {
                this.StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(this.Name, Action.Property, args.PropertyName!, key));
            }

            student.PropertyChanged += PropertyChangedHandler;
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                Student student = new Student();
                this.Add(student);
            }
        }

        public void AddStudents(Student[] students)
        {
            foreach (Student student in students)
            {
                TKey key = this.selector(student);
                this.Add(student);
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

        public bool Remove(Student student)
        {
            if(!this.students.ContainsValue(student))
            {
                return false;
            }

            var pair = this.students.First(st => st.Value == student);
            this.students.Remove(pair.Key);
            this.OnStudentsChanged(Action.Remove, pair.Key);

            return true;
        }

        public event StudentsChangedHandler<TKey> StudentsChanged;

        protected virtual void OnStudentsChanged(Action action, TKey element)
        {
            this.StudentsChanged.Invoke(this, new StudentsChangedEventArgs<TKey>(
                this.Name, 
                action, 
                null, 
                element));
        }
    }
}
