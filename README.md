# 📋 Examination Management System
A **console-based Examination Management System** built in C# that demonstrates advanced Object-Oriented Programming principles including inheritance, polymorphism, generics, events & delegates, and more.
---
## 📚 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [UML Class Diagram](#uml-class-diagram)
- [Class Hierarchy](#class-hierarchy)
- [Getting Started](#getting-started)
- [How It Works](#how-it-works)
- [Sample Output](#sample-output)
---
## Overview
This system simulates a real-world examination platform supporting multiple question types, student enrollment, exam lifecycle management, and automatic grading — all from the console.
The project was built as an academic assignment to demonstrate mastery of:
- ✅ Inheritance & Polymorphism  
- ✅ Generics with Constraints  
- ✅ Events & Delegates  
- ✅ Interfaces (`ICloneable`, `IComparable`)  
- ✅ Method Overriding (`ToString`, `Equals`, `GetHashCode`)  
- ✅ File I/O (`StreamWriter`, `StreamReader`)  
- ✅ Enums  
- ✅ Composition & Aggregation  
---
## Features
| Feature | Description |
|--------|-------------|
| 🧩 Multiple Question Types | True/False, Choose One, Choose All |
| 📝 Two Exam Modes | Practice Exam (with feedback) and Final Exam (no answers shown) |
| 🔔 Student Notifications | Event-driven notifications when an exam starts |
| ✔️ Auto Grading | Exams are corrected automatically on finish |
| 🗂️ Generic Repository | Type-safe storage with sorting and cloning support |
| 🔄 Exam Lifecycle | Managed via `ExamMode` enum (Starting → Queued → Finished) |
---
## UML Class Diagram
![Class Diagram](https://raw.githubusercontent.com/OmarMuhamad/Examination-Management-System/main/UML%20Diagrams/Examination%20Management%20System.png)
## Class Hierarchy
### Question Hierarchy
```
Question  (abstract)
├── TrueFalseQuestion
├── ChooseOneQuestion
└── ChooseAllQuestion
```
### Exam Hierarchy
```
Exam  (abstract, ICloneable, IComparable<Exam>, IExamBehavior)
├── PracticeExam
└── FinalExam
```
### Supporting Models
```
Answer          → IComparable<Answer>
AnswerList      → wraps Answer[]
QuestionList    → extends List<Question>
Subject         → contains Student[]
Repository<T>   → where T : ICloneable, IComparable<T>
```
---
## Getting Started
### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- C# 14
- Any terminal / Visual Studio / Rider
### Run the Project
```bash
git clone https://github.com/your-username/examination-management-system.git
cd examination-management-system
dotnet run
```
---
## How It Works
1. A **Subject** is created and **Students** are enrolled.
2. A **PracticeExam** and a **FinalExam** are prepared with questions.
3. The user selects an exam type:
   ```
   Select Exam Type:
   1 - Practice
   2 - Final
   ```
4. The exam **Mode** transitions to `Starting` → event fires → students are notified.
5. Questions are displayed one by one, and the student answers each.
6. On `Finish()`:
   - **PracticeExam**: Shows student answers, correct answers, and final grade.
   - **FinalExam**: Shows only the student's answers — no correct answers revealed.
---
## 🌟 Bonus Features

### 1. `IExamBehavior` Interface
A custom interface was implemented to define the **contract** for all exam types:

```csharp
internal interface IExamBehavior
{
    void Start();
    void Finish();
    void ShowExam();
    void CorrectExam();
}
```

The abstract `Exam` class implements `IExamBehavior` alongside `ICloneable` and `IComparable<Exam>`:

```csharp
internal abstract class Exam : ICloneable, IComparable<Exam>, IExamBehavior
```

This ensures that any exam type is guaranteed to provide `Start`, `Finish`, `ShowExam`, and `CorrectExam` behavior, making the design more extensible and following the **Interface Segregation Principle**.

---

### 2. Persist Exam Results to File
After every exam is finished, the results are **automatically saved to a file** (`results.txt`) using `StreamWriter`.

- **PracticeExam** saves: questions, student answers, correct answers, and final grade.
- **FinalExam** saves: questions and student answers only (no correct answers revealed).

The file is **overwritten** on each run to always reflect the latest exam session.

#### Sample `results.txt` output (Practice Exam):
```
=== Exam Results ===
Q1: Is 3 an odd number?
Your Answer: True
Correct Answer: True
Correct!
------------------
Q2: What is 2 + 2?
Your Answer: 4
Correct Answer: 4
Correct!
------------------
Q3: Which are even numbers?
Your Answers: 2, 4, 6
Correct Answers: 2, 4, 6
Correct!
------------------
Final Grade: 30
================================
```

---
## Sample Output
### Final Exam Console Output
![Final Exam](https://raw.githubusercontent.com/OmarMuhamad/Examination-Management-System/main/Screenshots/Final%20Exam.png)
### Practical Exam Console Output
![Practice Exam](https://raw.githubusercontent.com/OmarMuhamad/Examination-Management-System/main/Screenshots/Practical%20Exam.png)
---
## Author
**Omar Mohammed Fayek**  
Information Technology Institute (ITI)  
Course: C#  
---
> *"Clean code always looks like it was written by someone who cares."* — Robert C. Martin
