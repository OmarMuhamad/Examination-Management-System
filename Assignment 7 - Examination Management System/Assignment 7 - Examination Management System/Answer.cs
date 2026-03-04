using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    public class Answer : IComparable<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer(int id, string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Text cannot be null or empty");
            if (id <= 0) throw new ArgumentException("Id must be greater than 0");
            Id = id;
            Text = text;
        }
        public override string ToString()
        {
            return $"Answer Id is {Id}, Text: {Text}";
        }

        public override bool Equals(object? obj)
        {

            if (obj is Answer Right)
            {
                return this.Id == Right.Id && this.Text == Right.Text;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }

        public int CompareTo(Answer? other)
        {
            return this.Id.CompareTo(other?.Id);
        }
    }
}
