using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList AnswerList { get; set; }
        public Answer CorrectAnswer { get; set; } // for choose all it will be that "1 2 3"
        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);

        public Question(string header, string body, int marks, Answer answer)
        {
            if (string.IsNullOrEmpty(header)) throw new ArgumentException("Header cannot be null or empty");
            if (string.IsNullOrEmpty(body)) throw new ArgumentException("Body cannot be null or empty");
            if (marks <= 0) throw new ArgumentException("Marks must be greater than 0");
            if (answer == null) throw new ArgumentNullException("Answer cannot be null");
            Header = header;
            Body = body;
            Marks = marks;
            AnswerList = new AnswerList();
            CorrectAnswer = answer;
        }
        public override string ToString()
        {
            return $"Header: {Header} \nBody: {Body} \nMarks: {Marks}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Question q)
            {
                return q.Header == this.Header && q.Body == this.Body && q.Marks == this.Marks;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Header, this.Body);
        }
    }
}
