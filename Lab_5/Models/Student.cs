using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml.Linq;
using Lab_5.Enumerators;
using Lab_5.Logic;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab_5.Models
{
    [Serializable]
    internal class Student: Person, IEnumerable, INotifyPropertyChanged
    {
        private Education education;
        private int groupNumber;
        private List<Exam> exams;
        private List<Test> tests;
        private JsonManager<Student> jsonManager;

        public Student(
            Person person,
            Education education,
            int groupNumber)
        {
            this.firstName = person.FirstName;
            this.lastName = person.LastName;
            this.birthsday = person.Birthsday;
            this.education = education;
            this.GroupNumber = groupNumber;
            this.exams = new List<Exam>();
            this.tests = new List<Test>();
            this.jsonManager = new JsonManager<Student>("D:\\LABS\\C#\\LABS\\Lab_5\\Data\\");
        }

        public Student()
        {
            this.firstName = "Denis";
            this.lastName = "Kudruavcev";
            this.birthsday = new DateTime(2004, 5, 16);
            this.education = Education.SecondEducation;
            this.GroupNumber = 101;
            this.exams = new List<Exam>()
            {
                new Exam()
            };
            this.tests = new List<Test>()
            {
                new Test()
            };
            this.jsonManager = new JsonManager<Student>("D:\\LABS\\C#\\LABS\\Lab_5\\Data\\");
        }

        public Education Education
        {
            get { return this.education; }
            set
            {
                this.OnPropertyChanged("Education");
                this.education = value;
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 100 || value > 599)
                {
                    throw new ArgumentException("Invalid group number, integers from 100 to 599 are allowed");
                }

                this.groupNumber = value;

                this.OnPropertyChanged("GroupNumber");
            }
        }

        public IEnumerable<object> ExamsAndTests
        {
            get
            {
                ArrayList works = new ArrayList();
                works.AddRange(this.exams);
                works.AddRange(this.tests);

                for (int i = 0; i < works.Count; i++)
                {
                    yield return works[i];
                }
            }
        }

        public IEnumerable<Exam> ExamsWithMarkHigherThan(int mark)
        {
            foreach (Exam exam in this.exams)
            {
                if (exam.Mark > mark)
                {
                    yield return exam;
                }
            }
        }

        public IEnumerable<object> PassedExamsAndTests
        {
            get
            {
                for (int i = 0; i < this.exams.Count; i++)
                {
                    Exam exam = this.exams[i];

                    if (exam.Mark > 2)
                    {
                        yield return exam;
                    }
                }

                for (int i = 0; i < this.tests.Count; i++)
                {
                    Test test = (Test)this.tests[i];

                    if (test.IsPassed)
                    {
                        yield return test;
                    }
                }
            }
        }

        public IEnumerable<Test> PassedTestsWithExams
        {
            get
            {
                for (int i = 0; i < this.tests.Count; i++)
                {
                    Test test = (Test)this.tests[i];

                    if (!test.IsPassed)
                    {
                        continue;
                    }

                    for (int j = 0; j < this.exams.Count; j++)
                    {
                        Exam exam = (Exam)this.exams[j];

                        if (exam.Mark > 2 && exam.Name == test.Name)
                        {
                            yield return test;
                        }
                    }
                }
            }
        }

        public List<Exam> Exams
        {
            get { return this.exams; }
            set { this.exams = value; }
        }

        public List<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

        public double AverageMark
        {
            get { return this.exams.Cast<Exam>().Select(ex => ex.Mark).Sum(); }
        }


        public bool this[Education edc]
        {
            get { return this.education == edc; }
        }

        public void AddExams(Exam[] exams)
        {
            foreach (Exam exam in exams)
            {
                this.exams.Cast<Exam>().Append(exam);
            }
        }

        public override string ToString()
        {
            string result = $"First name: {this.firstName} Last name: {this.lastName} Birthsday: {this.Birthsday}" +
                            $"Education: {this.Education.ToString()} " +
                            $"Group: {this.groupNumber} " +
                            $"Exams: ";

            result = this.exams.Aggregate(result, (current, exam) => current + $"{exam.Name} ");

            result += "Tests: ";

            return this.tests.Aggregate(result, (current, test) => current + $"{test.Name} ");
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public new Student DeepCopy()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Student>(jsonString);
        }

        public bool Save(string fileName)
        {
            try
            {
                this.jsonManager.SaveToJson(this, fileName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Load(string fileName)
        {
            Student loaded = new Student();

            string _firstName = loaded.firstName;
            string _lastName = loaded.lastName;
            int _group = loaded.groupNumber;
            Education _education = loaded.education;
            List<Test> _tests = loaded.tests;
            List<Exam> _exams = loaded.exams;

            try
            {
                loaded = this.jsonManager.LoadJson(fileName);
                _firstName = loaded.firstName;
                _lastName = loaded.lastName;
                _group = loaded.groupNumber;
                _education = loaded.education;
                _tests = loaded.tests;
            }
            catch (Exception ex)
            {
                return false;
            }

            this.firstName = _firstName;
            this.lastName = _lastName;
            this.groupNumber = _group;
            this.Education = _education;
            this.tests = _tests;
            this.exams = _exams;
            
            return true;
        }

        public string ToShortString()
        {
            return $"First name: {this.firstName} Last name: {this.lastName} Birthsday: {this.Birthsday}" +
                   $"Education: {this.Education.ToString()} " +
                   $"Group: {this.groupNumber} " +
                   $"Average mark: {this.AverageMark} ";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;

            Student student = obj as Student;

            return (this.firstName == student.FirstName &&
                    this.lastName == student.LastName &&
                    this.birthsday == student.Birthsday &&
                    this.AverageMark == student.AverageMark &&
                    this.education == student.Education);
        }

        public static bool operator ==(Student left, Student right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left.Equals(right));
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() +
                   this.lastName.GetHashCode() +
                   this.birthsday.GetHashCode() +
                   this.groupNumber.GetHashCode() +
                   this.Exams.GetHashCode() +
                   this.Education.GetHashCode();
        }

        public void SortExamsByName()
        {
            this.exams.Sort();
        }

        public void SortExamsByMark()
        {
            this.Exams.Sort(new Exam());
        }

        public void SortExamsByDate()
        {
            this.Exams.Sort(new ExamComparator());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

    }
}
