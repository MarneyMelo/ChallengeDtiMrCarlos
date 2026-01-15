# DTI Digital Challenge - School Management

---

## About the Project
This repository contains my implementation for a challenge proposed by **dti**.  
The project focuses on processing **student grades and attendance**.

---

## Prerequisites
- .NET SDK 8.0 or later (tested with .NET 10.0.102, realeased on January 13, 2026)
- Any OS supported by .NET (tested on W11)
- Recommended IDE: Visual Studio or Visual Studio Code (tested on Visual Studio)

---

## How to Run 
1. Clone the repository:
```bash
https://github.com/MarneyMelo/challenge-dti-professor-carlos.git
```
2. Navigate to the project folder.
3. Run the aplication: 
```bash
dotnet run --project gradeManagement
```

---

## Input Format
- The application expects one student per line, following the format:
 `Name_Student Grade1 Grade2 Grade3 Grade4 Grade5 Attendance%`
- Data entry ends when the user input -1.

---

## Example

### Input
```
Joao 8 7 9 10 6 85%
Marney 10 9 8 7 6 95%
Pedro 5 6 5 4 6 70%
-1
```

### Output
```
Joao 8 85%
Marney 8 95%
Pedro 5 70%
8 7 7 7 6
Joao, Marney
Pedro
```

---

## Project Structure

The project follows the **Single Responsibility Principle (SRP)**, where each class has a specific purpose.

```
dtiProcessoSeletivo/
├── dtiProcessoSeletivo.sln        # Visual Studio solution file
├── README.md                      # Project documentation
├── gradeManagement/               # Main project (Console Application)
│   ├── Program.cs                 # Entry point: data input and output
│   ├── Models/                    # Entities
│   │   └── Student.cs             # Student class with properties and individual average
│   └── Services/                  # Processing logic
│       └── GradeCalculator.cs     # Calculates class averages and filters students
│                                    performance/attendance
└── gradeManagement.Tests/         # Accuracy Assurance project (xUnit)
    └── GradeCalculatorTests.cs    # Unit tests for business logic verification
```

--- 

## Technical Decisions

### Assumptions
- **Names:** Student names are expected to be a single string without spaces.
- **Grades:** Its assumed that all students have exactly 5 grades. 

### Architecture
- **Service Pattern** was adopted to isolate logic from input/output.
- The `Program.cs` serves as the entry point, handling user input and output
- The `Student` class represents all properties and data of each student.
- The `GradeCalculator` class is responsible for all calculations, improvig modularity, testability and maintainability.

### Data Processing
- **System.Globalization** is used to ensure consistent parsing of decimal values.
- Input parsing is protected with exception handling to avoid application crashes due to invalid input.

---

## Tests

The project includes a suite of unit tests to ensure the integrity of business rules and mathematical calculations. They were implemented to guarantee that the system has a expected behavior.

#### How to run tests:

1. Open a terminal in the solution root folder.
2. Run the command:

```bash
dotnet test

```

#### Scenarios covered:

- **Calculation Accuracy**: Validating class averages per subject.
- **Filtering Logic**: Ensuring students with attendance below 75% are correctly identified.
- **Performance Evaluation**: Verifying the logic for students performing above the class average.
- **Edge Cases**: Handling empty student lists to prevent application crashes.

---

## Future Improvements

1. **Web API Integration**:
- Transition the business logic from a Console Application to an **ASP.NET Core Web API**.

2. **Frontend Development (React)**:
- Build a modern user interface using **React** to replace the terminal input.

3. **Error Handling**:
- Improve the error handling with more friendly messages to enhance the UX.

---

## Project Status
The current version focuses on the core business logic. Although a frontend in React was listed as desirable, I prioritized the robustness and architecture of the back-end to ensure a solid and maintainable code. 
To go beyond the basics requirements, I implemented some **Unit Tests** to ensure the logic and mathematical accuracy of the aplication. I had not worked with React before, but I had already started studying it during this period.

---

## Author

**Marney Melo**  
Email: marney.melo@outlook.com  
GitHub: [MarneyMelo](https://github.com/MarneyMelo)

---

