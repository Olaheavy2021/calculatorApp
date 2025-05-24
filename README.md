# Calculator Console Application

## Overview

A modern command-line calculator application built with C# and .NET 8 that evaluates mathematical expressions. It supports basic operations: 
- addition `+`
- subtraction `-`
- multiplication `*`
- division `/`

The application processes these expressions from left to right and does not handle parentheses.

## Features

•	Evaluates basic mathematical expressions

•	Supports addition (+), subtraction (-), multiplication (*), and division (/)

•	Input validation with helpful error messages

•	Simple and intuitive command-line interface

## Get Started

### Installation

1. Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed
2. Clone the repository
```
git clone https://github.com/Olaheavy2021/calculatorApp
```
3. Navigate to the project directory
```
cd calculator-project
```
4. Build the application
```
dotnet build
```
### Usage

Run the application using:

```
dotnet run
```

Enter mathematical expressions when prompted:
```
5+5
```

To exit the application, type:
```
exit
```

## Error Handling

The calculator includes comprehensive error handling:
- Expressions must start with a digit or negative number
- Expressions must end with a digit
- No spaces are allowed in expressions
- Invalid operator usage is detected

## Technologies

- C# 12.0
- .NET 8
- Visual Studio 2022

## Future Enhancements

- Support for more complex operations (exponents, square roots, etc.)
- Memory functions
- History of calculations
- GUI interface
