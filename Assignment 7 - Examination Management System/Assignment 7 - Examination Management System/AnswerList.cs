using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    public class AnswerList
    {
        public List<Answer> answers { get; set; }
        public int Count { get; private set; }
        public AnswerList()
        {
            answers = new List<Answer>();
        }
        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);
        }
        public Answer? GetById(int id)
        {
            foreach(Answer answer in answers)
            {
                if (answer.Id == id)
                {
                    return answer;
                }
            }
            return null;
        }

       

        public Answer? this[int Id]
        {
            get
            {
                return GetById(Id);
            }
        }
    }
}
