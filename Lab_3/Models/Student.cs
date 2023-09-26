using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Interfaces;
using Lab_3.Enumerators;
using Lab_3.Logic;

namespace Lab_3.Models
{
    internal class Student: Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int groupNumber;
        private List<Exam> exams;
        private List<Test> tests;

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
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (value < 100 || value > 599)
                {
                    throw new ArgumentException("Invalid group number, integers from 100 to 599 are allowed");
                }

                groupNumber = value;
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
            get { return exams; }
            set { exams = value; }
        }

        public List<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

        public double AverageMark
        {
            get { return exams.Cast<Exam>().Select(ex => ex.Mark).Sum(); }
        }


        public bool this[Education edc]
        {
            get { return education == edc; }
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
            string result = $"First name: {firstName} Last name: {lastName} Birthsday: {Birthsday}" +
                            $"Education: {Education.ToString()} " +
                            $"Group: {groupNumber} " +
                            $"Exams: ";

            result = this.exams.Aggregate(result, (current, exam) => current + $"{exam.Name} ");

            result += "Tests: ";

            return this.tests.Aggregate(result, (current, test) => current + $"{test.Name} ");
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public Student  DeepCopy()
        {
            var student = new Student(
                new Person(this.firstName, this.lastName, this.birthsday),
                this.education,
                this.groupNumber)
            {
                Tests = this.tests,
                Exams = this.exams
            };

            return student;
        }

        public string ToShortString()
        {
            return $"First name: {this.firstName} Last name: {this.lastName} Birthsday: {this.Birthsday}" +
                   $"Education: {Education.ToString()} " +
                   $"Group: {groupNumber} " +
                   $"Average mark: {AverageMark} ";
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
    }
}
