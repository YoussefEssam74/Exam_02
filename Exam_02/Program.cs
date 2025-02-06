using System.Diagnostics;

namespace Exam_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You want to Start The Exam (y | n)");
            string input = Console.ReadLine();
            char userInput;
            if (char.TryParse(input, out userInput) && (userInput == 'y' || userInput == 'Y'))           {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                subject.Exam.StartExam();
                Console.WriteLine($"The Elapsed Time = {stopwatch.Elapsed}");
            }
        }
    }
}
