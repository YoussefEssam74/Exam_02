using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02
{
    internal class MCQ : Question
    {
        public MCQ(string header, string body, int marks, List<Answer> answers, int correctanswer) : base(header, body, marks)
        {
            Answers = answers;
            CorrectAnswer = correctanswer;
        }
        public override bool ValidateAnswer(object answer)
        {
            return answer.Equals(CorrectAnswer);
        }
    }
}
