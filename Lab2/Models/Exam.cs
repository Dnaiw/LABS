using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Interfaces;

namespace Lab2.Models
{
    internal class Exam: IDateAndCopy
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

        public object DeepCopy()
        {
            return new Exam(this.Name, this.Mark, this.Date);
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