using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string header, string body, int marks) : base(header, body, marks)
        {
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer); 
        }

        public override void Display()
        {
            Console.WriteLine($"Q: {Body}");
            foreach (Answer? answer in AnswerList.answers)
                Console.WriteLine($"{answer.Id}. {answer.Text}");
        }
    }
}
