

using System.Threading.Tasks.Dataflow;
using Lab_3.Models;
using Lab_3.Models.Collections;
using Lab_3.Logic;

internal class Program
{
    static void Main(string[] args)
    {
        Student student = new Student()
        {
            Exams = new List<Exam>()
            {
                new Exam("Linal", 5, new DateTime(2022, 5, 16)),
                new Exam("Matan", 4, new DateTime(2022, 5, 13)),
                new Exam("Algebra", 2, new DateTime(2022, 5, 18)),
                new Exam("Geomaetry", 1, new DateTime(2022, 5, 10)),
                new Exam("Eanglish", 3, new DateTime(2022, 5, 20)),
            }
        };

        student.SortExamsByName();
        Console.WriteLine("Exams sorted by name:");
        Console.WriteLine(student.ToString());

        student.SortExamsByMark();
        Console.WriteLine("Exams sorted by mark:");
        Console.WriteLine(student.ToString());

        student.SortExamsByDate();
        Console.WriteLine("Exams sorted by date:");
        Console.WriteLine(student.ToString());

        Console.WriteLine("\n------------------------------------------------\n");

        StudentCollection<string> studentCollection = new StudentCollection<string>(Selector.SelectKey);
        studentCollection.AddDefaults();

        Console.WriteLine(studentCollection.ToString());

        Console.WriteLine("\n------------------------------------------------\n");

        studentCollection.AddStudents(new Student[]
        {
            new Student()
            {
                Exams = new List<Exam>()
                {
                    new Exam("Linal", 5, new DateTime(2022, 5, 16)),
                    new Exam("Matan", 4, new DateTime(2022, 5, 13)),
                    new Exam("Algebra", 2, new DateTime(2022, 5, 18)),
                    new Exam("Geomaetry", 1, new DateTime(2022, 5, 10)),
                    new Exam("Eanglish", 3, new DateTime(2022, 5, 20)),
                },

                Education = Education.Bachelor
            },
            new Student()
            {
                Exams = new List<Exam>()
                {
                    new Exam("Linal", 5, new DateTime(2022, 5, 16)),
                    new Exam("Matan", 3, new DateTime(2022, 5, 13)),
                    new Exam("Algebra", 3, new DateTime(2022, 5, 18)),
                    new Exam("Geomaetry", 3, new DateTime(2022, 5, 10)),
                    new Exam("Eanglish", 3, new DateTime(2022, 5, 20)),
                },

                Education = Education.SecondEducation
            },
            new Student()
            {
                Exams = new List<Exam>()
                {
                    new Exam("Linal", 5, new DateTime(2022, 5, 16)),
                    new Exam("Matan", 4, new DateTime(2022, 5, 13)),
                    new Exam("Algebra", 5, new DateTime(2022, 5, 18)),
                    new Exam("Geomaetry", 5, new DateTime(2022, 5, 10)),
                    new Exam("Eanglish", 5, new DateTime(2022, 5, 20)),
                },

                Education = Education.SecondEducation
            },
            new Student()
            {
                Exams = new List<Exam>()
                {
                    new Exam("Linal", 3, new DateTime(2022, 5, 16)),
                    new Exam("Matan", 4, new DateTime(2022, 5, 13)),
                    new Exam("Algebra", 2, new DateTime(2022, 5, 18)),
                    new Exam("Geomaetry", 5, new DateTime(2022, 5, 10)),
                    new Exam("Eanglish", 3, new DateTime(2022, 5, 20)),
                },

                Education = Education.Bachelor
            },
        });

        Console.WriteLine("Maximum average mark: ", studentCollection.MaxAverageMark);
        Console.WriteLine("Bachelor students: ");

        foreach (KeyValuePair<string, Student> pair in studentCollection.GetStudentsWithEducation(Education.Bachelor))
        {
            Console.WriteLine(pair.Value.ToString());
        }

        Console.WriteLine("\nGroups by education: ");

        foreach (var group in studentCollection.GroupByEducation())
        {
            Console.WriteLine(group.Key + ":");
            foreach (var pair in group)
            {
                Console.WriteLine(pair.Value.ToShortString());
            }
        }

        TestCollections<Person, Student> testCollections = new TestCollections<Person, Student>(1000000, i =>
        {
            Person person = new Person($"Name-{i}", $"Last {i}", new DateTime(2016, 5, 16));
            Student student = new Student(new Person(), Education.Bachelor, 102);
            return new KeyValuePair<Person, Student>(person, student);
        });

        List<TestCollectionTimeTestReply> reply = testCollections.TestAll();

        foreach (TestCollectionTimeTestReply testReply in reply)
        {
            Console.WriteLine(testReply.Name + ":");
            Console.WriteLine("\t First element: " + testReply.FirstElement);
            Console.WriteLine("\t Last element: " + testReply.LastElement);
            Console.WriteLine("\t Non existed element: " + testReply.NotExistingElement);
            Console.WriteLine("\t Center element: " + testReply.CenterElement);
        }

        

    }
}
