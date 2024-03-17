# Calculator Console Application Design Documentation

## Overview

The Calculator Console Applications is designed as a modern, object-oriented solution for parsing, evaluating, and displaying the results of arithmetic expressions input by users. The application ensures accurate mathematical evaluations using the shunting-yard algorithm to convert infix expressions to postfix notation. This documentation outlines the software design, emphasising object-oriented programming (OOP), adherence to SOLID principles, composition, and the role of unit testing in ensuring application reliability and maintainability.
##  Object-Oriented Programming (OOP)

The application leverages OOP principles by utilising a class hierarchy for expression tokens:

- Token: As the base class for different types of tokens found in arithmetic expressions. It abstracts common attributes and behaviours.
- NumberToken and OperatorToken: These subclasses inherit from Token, specializing in representing numeric values and operators, respectively. This design allows the application to extend support for additional token types in the future easily.

This approach encapsulates token-specific behaviour, enabling polymorphic processing of arithmetic expressions.

## SOLID Principles

The application's design adheres to SOLID principles:

- Single Responsibility Principle (SRP): Each class has a single responsibility. For example, the `BasicCalculator` class is solely responsible for orchestrating the calculation process, while `BasicCalculatorProcessor` handles the parsing, conversion, and evaluation logic.
- Open/Closed Principle (OCP): The application is open for extension but closed for modification. New token types or calculation features can be added without altering existing code, exemplified by the ability to extend the Token class hierarchy. This is the same for adding a new type of Calculator maybe a ScientificCalculator.
- Liskov Substitution Principle (LSP): Subtypes can replace their base types without affecting the correctness of the program. `NumberToken` and `OperatorToken` can be used anywhere a Token is expected.
- Interface Segregation Principle (ISP): The application defines specific interfaces, such as `IInputValidator` and `ICalculator`, ensuring that classes implement only the methods they use.
- Dependency Inversion Principle (DIP): High-level modules do not depend on low-level modules but on abstractions. This is evident in the use of interfaces like `ICalculatorProcessor` to decouple the calculation logic from the UI and `CalculationEngine`.

## Use of Composition and Abstraction

The application design leverages interfaces ( `ICalculatorProcessor` , `IInputValidator` , `IUserInterface` ) to define contracts for different operations and abstract class ( `CalculatorProcessorBase` , `Token` ) that provides a base implementation. This approach helps to ensure that any class implementing these interfaces provides specific functionalities, allowing for interchangeable processing strategies that adhere to the same set of operations.
Furthermore the use of abstract classes helps to share common logic, flexibility and leaves a room for customisation if needed.

## Writing Unit Tests

Unit testing is integral to the application's development process, providing several benefits:

- Reliability: Tests ensure that each component behaves as expected under various scenarios.
- Maintainability: By validating the behavior of isolated units, tests make it safer to refactor and improve the codebase.
- Documentation: Unit tests serve as practical documentation for how components are supposed to work.
- Design: The need for testable code encourages cleaner, more modular design choices, adhering to SOLID principles.

## Diagrams

```
        +--------+                           
        | Token  |                    
        +--------+
           ^   ^
          /     \
         /       \
        /         \
+------------+ +-------------+
|NumberToken| |OperatorToken|
+------------+ +-------------+

  +--------------------------------+       +-----------------------------------+
  |      <<interface>>             |       |          <<abstract>>             |
  |      ICalculatorProcessor      |<-----|       CalculatorProcessorBase      |
  +--------------------------------+       +-----------------------------------+
                                         /_\              |                     
                                          |               |                     
                                          |               |                     
  +-------------------------------+       |       +-----------------------------+
  |       BasicCalculator         |       |       |    BasicCalculatorProcessor |
  +-------------------------------+       |       +-----------------------------+
  | -processor: ICalculatorProcessor | -------> |                             |
  +-------------------------------+               +-----------------------------+


```

## Shunting-Yard Algorithm
The shunting-yard algorithm, developed by Edsger Dijkstra, is an efficient method for parsing mathematical expressions specified in infix notation and converting them into postfix notation, also known as Reverse Polish Notation (RPN). The algorithm utilises a stack for operators, a queue for numbers, and another stack for the output; the algorithm adeptly manages operator precedence and associativity rules, ensuring expressions are evaluated correctly, and this eventually leads to the effective conversion of infix to postfix expressions, which can be processed using a straightforward, stack-based method. This method allows operators to be applied to operands directly in a left-to-right order, streamlining the calculation process without juggling precedence or special grouping rules.

## Design Patterns
- Facade
- Factory

## Conclusion

The Calculator Console Application exemplifies a well-structured, object-oriented software design that adheres to SOLID principles, utilizes composition and interfaces for flexible and decoupled architecture, and emphasizes the importance of unit testing for ensuring software quality and maintainability.