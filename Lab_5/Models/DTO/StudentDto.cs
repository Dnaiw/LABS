using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Models.DTO
{
    internal class StudentDto
    {
        public Education Education { get; set; }
        public int GroupNumber { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Test> Tests { get; set; }
    }
}
