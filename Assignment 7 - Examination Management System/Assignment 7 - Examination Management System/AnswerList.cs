using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    public class AnswerList
    {
        public List<Answer> answers { get; set; }
        public int Count => answers.Count;
        public AnswerList()
        {
            answers = new List<Answer>();
        }
        public void Add(Answer answer) // composition
        {
            if (answer == null) throw new ArgumentNullException("Answer cannot be null");
            answers.Add(answer);
        }
        public Answer? GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Id must be greater than 0");

            foreach (Answer answer in answers)
            {
                if (answer.Id == id)
                    return answer;
            }
            return null;
        }
        public Answer? this[int index]
        {
            get
            {
                if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative");
                if (index >= answers.Count) throw new IndexOutOfRangeException($"Index {index} is out of range");
                return answers[index];
            }
        }
    }
}
