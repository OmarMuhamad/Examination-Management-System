using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class ChooseAll : Question
    {
        public ChooseAll(string header, string body, int marks, Answer answer) : base(header, body, marks, answer)
        {
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            var correctIds = CorrectAnswer.Text.Split(' ').ToHashSet();
            var studentIds = studentAnswer.Text.Split(' ').ToHashSet();

            return correctIds.SetEquals(studentIds);
        }
        
        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body} (Select All that apply)");
            foreach (Answer answer in AnswerList.answers)
                Console.WriteLine($"{answer.Id}. {answer.Text}");
        }
    }
}
