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
        public Answer CorrectAnswer { get; set; }
        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);

        public Question(string header, string body, int marks)
        {
            if (header == null) throw new ArgumentException("Header cannot be null");
            if (body == null) throw new ArgumentException("Body cannot be null");
            if (marks <= 0) throw new ArgumentException("Marks must be greater than 0");

            Header = header;
            Body = body;
            Marks = marks;
            AnswerList = new AnswerList();
        }
        public override string ToString()
        {
            return $"Header: {Header} | Body: {Body} | Marks: {Marks}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Question q)
            {
                return q.Header == this.Header && q.Body == this.Body;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Header, this.Body);
        }
    }
}
