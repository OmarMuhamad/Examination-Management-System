using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    internal class Subject
    {
        public string Name { get; set; }
        public List<Student> students { get; set; }

        public Subject(string name)
        {
            Name = name;
            students = new List<Student>();
        }
        public bool Enroll(Student student)
        {
            if (students.Contains(student))
            {
                return false;
            }
            students.Add(student);
            return true;
        }
        public void NotifyStudents(Exam exam)
        {
            foreach(Student s in students)
            {
                exam.ExamStarted += s.OnExamStarted; // subscripe all the students
            }
        }
    }
}
