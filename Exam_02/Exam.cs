using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    internal abstract class Exam
    {
        public int ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int examtime, int numberOfQuestions)
        {
            ExamTime = examtime;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public abstract void StartExam();

    }
}
