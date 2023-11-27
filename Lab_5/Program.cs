using Lab_5.Logic;
using Lab_5.Models;

namespace LABS.Lab_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonManager<Student> manager = new JsonManager<Student>("D:\\LABS\\C#\\LABS\\Lab_5\\Data\\");
            Student student = new Student();

            student.Exams.Add(new Exam()
            {
                Mark = 4,
                Name = "Maaaaaaath",
                Date = DateTime.Now
            });

            student.Education = Education.Bachelor;

            Student studentCopy = student.DeepCopy();

            Console.WriteLine("Student");
            Console.WriteLine(student.ToString());
            Console.WriteLine("\nStudent copy");
            Console.WriteLine(studentCopy.ToString());

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Enter filename");
            string filename = Console.ReadLine();


            if (!manager.IsExists(filename))
            {
                Console.WriteLine("New file created");
                student.Save(filename);
            }
            else
            {
                student.Load(filename);
            }

            Console.WriteLine("\nUpdatedStudent\n-------------------------");
            Console.WriteLine(student.ToString());
            Console.WriteLine("\n");

            student.AddExamFromConsole();
            student.Save(filename);

            Console.WriteLine("\nUpdatedStudent\n-------------------------");
            Console.WriteLine(student.ToString());

            Student.Load(student, filename);
            student.AddExamFromConsole();
            Student.Save(student, filename);

            Console.WriteLine("\nUpdatedStudent\n-------------------------");
            Console.WriteLine(student.ToString());
        }
    }
}

