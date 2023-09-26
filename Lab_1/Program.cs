    using System.ComponentModel;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Xml.Schema;
    using Lab_1.Models;
    using Lab_1.Logic;

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(); 
            Console.WriteLine("Student info: " + student.ToShortString());
            Console.WriteLine("Is Education.Specialist: " + student[Education.Specialist]);
            Console.WriteLine("Is Education.Bachelor: " + student[Education.Bachelor]);
            Console.WriteLine("Is Education.SecondEducation: " + student[Education.SecondEducation]);

            student.Exams = new Exam[]
            {
                new Exam(),
                new Exam("Linal", 5, DateTime.Now)
            };
            Console.WriteLine(student.ToString());

            student.AddExams(new Exam[]
            {
                new Exam(),
                new Exam(),
                new Exam()
            });

            Console.WriteLine(student.ToString());

            Exam[] oneD = new Exam[100000];

            for (int i = 0; i < 100000; i++)
            {
                oneD[i] = new Exam();
            }

            Exam[,] twoD = new Exam[50000, 2];

            for (int i = 0; i < 50000; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    twoD[i,j] = new Exam();    
                }
            }

            Exam[][] sD = new Exam[50000][];

            for (int i = 0; i < 50000; i++)
            {
                sD[i] = new Exam[] { new Exam(), new Exam() };
            }

            CompareService<Exam> compareService = new CompareService<Exam>();

            CompareServiceResult result = compareService.CompareTime(oneD, twoD, sD);

            Console.WriteLine($"One dimension time: {result.OneDimensionTime}\n" +
                              $"Two dimension time: {result.TwoDimensionTime}\n" +
                              $"Stairs time: {result.StairsTime}");
        }
    }
