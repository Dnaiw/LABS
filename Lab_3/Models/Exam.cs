using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Interfaces;

namespace Lab_3.Models
{
    internal class Exam: IDateAndCopy, IComparable, IComparer<Exam>
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

        public Exam(
            string name,
            int mark,
            DateTime date)
        {
            Name = name;
            Mark = mark;
            Date = date;
        }

        public Exam()
        {
            Name = "Matan";
            Mark = 5;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Name} {Mark} {Date}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is Exam exam)
            {
                return this.Name.CompareTo(exam.Name);
            }
            else
            {
                throw new ArgumentException("Invalid parametrs value");
            }
        }

        public object DeepCopy()
        {
            return new Exam(this.Name, this.Mark, this.Date);
        }

        public int Compare(Exam? x, Exam? y)
        {
            return x.Mark - y.Mark;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Exam exam = obj as Exam;

            return (this.Name.Equals(exam.Name) &&
                    this.Date.Equals(exam.Date) &&
                    this.Mark.Equals(exam.Mark));
        }

        public static bool operator ==(Exam left, Exam right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Exam left, Exam right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() +
                   this.Date.GetHashCode() +
                   this.Name.GetHashCode();
        }
    }
}