
using System;
using System.Collections;
using Lab2.Models;

internal class Program
{
    static void Main(string[] args)
    {
        Person personA = new Person();
        Person personB = new Person();

        Console.WriteLine("Compare two people: " + (personB == personA));
        Console.WriteLine($"Person 1 hash: {personA.GetHashCode()} | Person 2 hash: {personB.GetHashCode()}");

        Console.WriteLine("\n-------------------------------------\n");

        Student student = new Student();

        student.Tests = new ArrayList()
        {
            new Test(),
            new Test()
        };

        Console.WriteLine("Students info: " + student.ToString());

        Console.WriteLine("\n-------------------------------------\n");

        Student studentB = student.DeepCopy();
        studentB.FirstName = "Olya";

        Console.WriteLine("Student: " + student.ToString());
        Console.WriteLine("Clone: " + studentB.ToString());

        Console.WriteLine("\n-------------------------------------\n");

        try
        {
            studentB.GroupNumber = 34412;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " +  ex.Message);
        }
        Console.WriteLine("\n-------------------------------------\n");

        Console.WriteLine("Tests and exams: ");

        foreach (object work in (IEnumerable)student.ExamsAndTests)
        {
            Console.WriteLine(work.ToString());
        }

        Console.WriteLine("\n-------------------------------------\n");
        Console.WriteLine("Exams with mark higher than 3");

        foreach (Exam exam in (IEnumerable<Exam>)student.ExamsWithMarkHigherThan(3))
        {
            Console.Write(exam.ToString());
        }


        Console.WriteLine("\n-------------------------------------\n");

        student.Exams.AddRange(new Exam[]
        {
            new Exam("dotnet", 5, DateTime.Now),
            new Exam("java", 5, DateTime.Now),
        });

        student.Tests.AddRange(new Test[]
        {
            new Test("dotnet", true),
            new Test("java", true),
        });


        foreach (Test test in student.Tests)
        {
            foreach (Exam exam in student.Exams)
            {
                if (exam.Name == test.Name)
                {
                    Console.WriteLine(exam.Name);
                }
            }
        }

        Console.WriteLine("\n-------------------------------------\n");

        foreach (object work in student.PassedExamsAndTests)
        {
            Console.WriteLine(work.ToString());
        }

        Console.WriteLine("\n-------------------------------------\n");

        foreach (object work in student.PassedTestsWithExams)
        {
            Console.WriteLine(work.ToString());
        }

    }
}
