# Prelim Activity 02 – Advanced Object-Oriented Programming and Robustness

**Name:** Justine Marcella
**Scenario:** Eco-Grid Energy Distributor
**Course/Section:** BSIT 3.2

## Project Overview

This project demonstrates the application of advanced Object-Oriented Programming (OOP) principles in C#. The system simulates an energy distribution monitoring tool that analyzes different power sources and generates performance reports.

The implementation focuses on:

* Inheritance
* Encapsulation
* Polymorphism
* Abstraction
* Exception Handling

## Scenario Description

The **Eco-Grid Energy Distributor** manages different types of renewable energy sources. A base class `PowerSource` defines common properties, while specialized subclasses (`SolarPanel` and `WindTurbine`) implement their own energy reporting logic.

The system ensures robustness by validating inputs and handling runtime errors using structured exception handling.

## OOP Concepts Implemented

### Encapsulation

* All fields are declared **private**.
* Public properties control access and validate values.
* Prevents invalid negative weather inputs.

### Inheritance

* `SolarPanel` and `WindTurbine` inherit from `PowerSource`.
* Reduces code duplication.
  
### Polymorphism

* `GenerateReport()` is declared **virtual** in the base class.
* Subclasses **override** the method.
* The correct method executes at runtime based on object type.

### Abstraction

* The base class defines shared structure and behavior.
* Subclasses provide specific implementations.

### Robustness (Exception Handling)

* `ArgumentException` is thrown for invalid inputs.
* `try-catch-finally` prevents application crashes.
* `finally` ensures graceful shutdown.

## Project Structure

```
PowerSource (Base Class)
│
├── SolarPanel (Subclass)
└── WindTurbine (Subclass)
```

## How to Run

1. Open the solution file in **Visual Studio**.
2. Build the project.
3. Run the console application.
4. Observe the generated energy reports and exception handling behavior.

## Exception Scenarios Handled

* Negative sunlight percentage
* Negative wind speed
* General runtime errors in Main

## Expected Output

The program will:

* Create different power source objects
* Generate summary and detailed reports
* Demonstrate polymorphic behavior
* Handle invalid inputs safely
* Display **"System Shutdown"** at program end

---

## Submission Notes

This repository contains the source code for **Prelim Activity 02**. The accompanying PDF submission includes:

* UML Diagram
* Logic Explanation
* Code Screenshots
* Output Screenshots
* Knowledge Check Answers

---

## Author

**Justine Marcella**
---

> This project demonstrates the transition from basic programming to structured software architecture using professional OOP practices.
