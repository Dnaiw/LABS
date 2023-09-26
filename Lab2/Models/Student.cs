using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Interfaces;
using Lab2.Enumerators;

namespace Lab2.Models
{
    internal class Student: Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int groupNumber;
        private ArrayList exams;
        private ArrayList tests;

        public Student(
            Person person,
            Education education,
            int groupNumber)
        {
            this.firstName = person.FirstName;
            this.lastName = person.LastName;
            this.birthsday = person.Birthsday;
            this.education = education;
            this.groupNumber = groupNumber;
        }

        public Student()
        {
            this.firstName = "Denis";
            this.lastName = "Kudruavcev";
            this.birthsday = new DateTime(2004, 5, 16);
            education = Education.SecondEducation;
            groupNumber = 0;
            exams = new ArrayList()
            {
                new Exam()
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
            foreach (Exam exam in this.exams.Cast<Exam>())
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
                    Exam exam = (Exam)this.exams[i];

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

        public ArrayList Exams
        {
            get { return exams; }
            set { exams = value; }
        }

        public ArrayList Tests
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

            foreach (Exam exam in exams)
            {
                result += $"{exam.Name} ";
            }

            result += "Tests: ";

            foreach (Test test in tests)
            {
                result += $"{test.Name} ";
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public Student DeepCopy()
        {
            Student student = new Student(
                new Person(this.firstName, this.lastName, this.birthsday), 
                this.education, 
                this.groupNumber);
            student.Tests = new ArrayList(this.tests);
            student.Exams = new ArrayList(this.exams);

            return student;
        }

        public string ToShortString()
        {
            return $"First name: {firstName} Last name: {lastName} Birthsday: {Birthsday}" +
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
    }
}
