using Lab_4.Logic;
using Lab_4.Models;
using Lab_4.Models.Collections;
using Lab_4.Models.Events;

internal class Program
{
    static void Main(string[] args)
    {
        StudentCollection<string> collectionA = new StudentCollection<string>(Selector.SelectKey);
        StudentCollection<string> collectionB = new StudentCollection<string>(Selector.SelectKey);
        collectionA.Name = "collectionA";
        collectionB.Name = "collectionB";

        Journal<string> logger = Journal<string>.Instance;

        collectionA.StudentsChanged += logger.StudentChanged;
        collectionB.StudentsChanged += logger.StudentChanged;

        collectionA.AddDefaults();
        collectionB.AddDefaults();

        foreach (var student in collectionA.Students)
        {
            student.Value.GroupNumber = 123;
        }
        Console.WriteLine(logger.ToString());

        Student removed = collectionA.Students.First().Value;
        collectionA.Remove(removed);

        removed.Education = Education.Bachelor;

        Console.WriteLine("\n\nAfter Removing\n\n");
        Console.WriteLine(logger.ToString());
    }
}