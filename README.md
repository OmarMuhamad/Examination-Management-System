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
Exam  (abstract, ICloneable, IComparable<Exam>)
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
5. Questions are displayed one by one and the student answers each.
6. On `Finish()`:
   - **PracticeExam**: Shows student answers, correct answers, and final grade.
   - **FinalExam**: Shows only the student's answers — no correct answers revealed.

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
Course: Object-Oriented Programming / Advanced C#  

---

> *"Clean code always looks like it was written by someone who cares."* — Robert C. Martin
