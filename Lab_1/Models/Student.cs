using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    internal class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private Exam[] exams;

        public Student(
            Person person, 
            Education education,
            int groupNumber)
        {
            this.person = person;
            this.education = education;
            this.groupNumber = groupNumber;
            this.exams = new Exam[0];
        }

        public Student()
        {
            this.person = new Person();
            this.education = Education.SecondEducation;
            this.groupNumber = 0;
            this.exams = new Exam[]
            {
                new Exam()
            };
        }

        public Person Person
        {
            get { return this.person; } 
            set { this.person = value; }
        }

        public Education Education
        {
            get { return this.education;}
            set { this.education = value;}
        }

        public int GroupNumber
        {
            get { return this.groupNumber;}
            set { this.groupNumber = value; }
        }

        public Exam[] Exams
        {
            get { return this.exams;}
            set { this.exams = value;}
        }

        public double AverageMark
        {
            get { return this.exams.Select(ex => ex.Mark).Sum();  }
        }

        public bool this[Education edc]
        {
            get { return this.education == edc;  }
        }

        public void AddExams(Exam[] exams)
        {
            foreach (Exam exam in exams)
            {
                this.exams.Append(exam);
            }
        }

        public override string ToString()
        {
            string result = $"{this.person.ToString()} " +
                            $"Education: {this.Education.ToString()} " +
                            $"GroupNumber: {this.groupNumber} Exams: ";

            foreach (Exam exam in this.exams)
            {
                result += $"{exam.Name} ";
            }

            return result;
        }

        public string ToShortString()
        {
            return $"{this.person.ToString()} " +
                   $"Education: {this.Education.ToString()} " +
                   $"Group number: {this.groupNumber} " +
                   $"Average mark: {this.AverageMark} ";
        }
    }
}
