using System;
using System.Collections.Generic;

namespace Exam_02
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            // Validate the exam type input (1 for Practical | 2 for Final)
            int examType = 0;
            do
            {
                Console.WriteLine("Please Enter The Type Of Exam You Want To Create (1 for Practical | 2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            // Validate the exam time input (30 min to 180 min)
            int time = 0;
            do
            {
                Console.WriteLine("Please Enter the time For Exam From (30 min to 180 min): ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 30 || time > 180);

            // Validate the number of questions input (positive number)
            int numQuestions = 0;
            do
            {
                Console.WriteLine("Please Enter the Number Of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0);

            if (examType == 1)
            {
                Exam = new PracticaExam(time, numQuestions);

                for (int i = 0; i < numQuestions; i++)
                {
                    string body;
                    // Validate body input (non empty and non null)
                    do
                    {
                        Console.WriteLine($"Please Enter the Body of Question ({i + 1}): ");
                        body = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(body))
                        {
                            Console.WriteLine("Body cannot be empty. Please enter a valid question body.");
                        }
                    } while (string.IsNullOrWhiteSpace(body));

                    int mark;
                    // Validate marks input (positive integer)
                    do
                    {
                        Console.WriteLine("Please Enter The Marks of Question: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    List<Answer> answers = new List<Answer>();
                    for (int j = 0; j < 4; j++)
                    {
                        string ans;
                        // Validate that answer choices are not empty
                        do
                        {
                            Console.WriteLine($"Please Enter the Answer Number ({j + 1}): ");
                            ans = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(ans))
                            {
                                Console.WriteLine("Answer cannot be empty. Please provide a valid answer.");
                            }
                        } while (string.IsNullOrWhiteSpace(ans));

                        answers.Add(new Answer(j + 1, ans));
                    }

                    int correctAnswerId;
                    // Validate correct answer ID input (1 to 4)
                    do
                    {
                        Console.WriteLine("Please Enter the Correct Answer Id (1 to 4): ");
                    } while (!int.TryParse(Console.ReadLine(), out correctAnswerId) || correctAnswerId < 1 || correctAnswerId > 4);

                    Exam.AddQuestion(new MCQ("MCQ Questions", body, mark, answers, correctAnswerId));
                }
            }
            else
            {
                Exam = new FinalExam(time, numQuestions);

                for (int i = 0; i < numQuestions; i++)
                {
                    int qType;
                    // Validate question type input (1 for True/False || 2 for MCQ)
                    do
                    {
                        Console.WriteLine($"Please choose the Type of Question Number ({i + 1}) (1 for T/F || 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2));

                    string body;
                    // Validate body input (non empty and non null)
                    do
                    {
                        Console.WriteLine("Please Enter the Body of Question: ");
                        body = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(body))
                        {
                            Console.WriteLine("Body cannot be empty. Please enter a valid question body.");
                        }
                    } while (string.IsNullOrWhiteSpace(body));

                    int mark;
                    // Validate marks input (positive integer)
                    do
                    {
                        Console.WriteLine("Please Enter The Marks of Question: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                    if (qType == 1) // True/False question
                    {
                        int correctAnswer;
                        // Validate correct answer input (1 for True | 2 for False)
                        do
                        {
                            Console.WriteLine("Please Enter the Correct Answer (1 for True | 2 for False): ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || (correctAnswer != 1 && correctAnswer != 2));

                        Exam.AddQuestion(new TrueOrFalse("True/False Questions", body, mark, correctAnswer));
                    }
                    else // MCQ question
                    {
                        List<Answer> answers = new List<Answer>();
                        for (int j = 0; j < 4; j++)
                        {
                            string ans;
                            // Validate that answer choices are not empty
                            do
                            {
                                Console.WriteLine($"Please Enter the Answer Number ({j + 1}): ");
                                ans = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(ans))
                                {
                                    Console.WriteLine("Answer cannot be empty. Please provide a valid answer.");
                                }
                            } while (string.IsNullOrWhiteSpace(ans));

                            answers.Add(new Answer(j + 1, ans));
                        }

                        int correctAnswerId;
                        // Validate correct answer ID input (1 to 4)
                        do
                        {
                            Console.WriteLine("Please Enter the Correct Answer Id (1 to 4): ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswerId) || correctAnswerId < 1 || correctAnswerId > 4);

                        Exam.AddQuestion(new MCQ("MCQ Questions", body, mark, answers, correctAnswerId));
                    }
                }
            }
        }
    }
}
