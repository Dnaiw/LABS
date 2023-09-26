using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    internal class Exam
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }

        public Exam(
            string name,
            int mark,
            DateTime date)
        {
            this.Name = name;
            this.Mark = mark;  
            this.Date = date;
        }

        public Exam()
        {
            this.Name = "Matan";
            this.Mark = 5;
            this.Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Mark} {this.Date}";
        }
    }
}
