using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class Student
    {
        public String Name { get; set; }
        public int Id { get; set; }

        public Student(string name, int id) {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty");
            if (id <= 0) throw new ArgumentException("Id must be greater than 0");
            Name = name;
            Id = id;
        }
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Exam Has Started for Student {Name}, {Id} in Subject: {e.Subject.Name}");
        }
        public override string ToString()
        {
            return $"Student: {Name}, ID: {Id}";
        }
    }
}
