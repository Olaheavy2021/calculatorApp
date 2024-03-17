# Calculator Console Application Manual

## Overview

This manual provides instructions for using the Calculator Console Application developed in C#. The application processes expressions input by the user, validates them, and displays the results. It supports basic operations: addition `+`, subtraction `-`, multiplication `*`, and division `/`. The application processes these expressions from left to right and does not handle parentheses.

## Features

- **Arithmetic Operations**: Supports basic operations (addition, subtraction, multiplication, division).
- **Input Validation**: Ensures the input expressions are valid before calculation.
- **Error Handling**: Displays meaningful error messages for invalid inputs or calculation errors.
- **Colour-Coded Messages**: Displays regular messages in green and error messages in red for easy distinction.

## Get Started

### Installation

Ensure you have the .NET 8.0 SDK and Visual Studio 2022 installed on your machine to compile and run the C# application.
- Open a command prompt or terminal.
- Navigate to the directory containing the Calculator Console Application.
- Restore required packages by running

  ```
  dotnet restore
  ```
- Next, build the solution by running
  ```
  dotnet build
  ```

### Launching the Application

Within the application directory, launch the back end by running:
```
dotnet run
```

## Using the Application

Upon launching the application, you will be greeted with a welcome message. The application then waits for you to input an arithmetic expression.

### Inputting Expressions

Type your arithmetic expression using numbers and the supported operators and then press `Enter` to submit the expression for evaluation.
For example:
- Valid Input
```
  10-2*6/4
```
- Invalid Input
```
  10 - 2*6/4
```
```
  10-+2*6/4
```

### Viewing Results

- For valid expressions, the application displays the result in a box format, highlighted in green.
- For invalid expressions or errors during calculation, an error message is displayed in red.

### Supported Operations

- **Addition `+`** : Adds two numbers.
- **Subtraction `-`** : Subtracts the second number from the first.
- **Multiplication `*`** : Multiplies two numbers.
- **Division `/`** : Divides the first number by the second. Note: Division by zero will result in an error.

### Error Messages

The application validates input expressions for common errors, such as:

- Spaces in Expressions: Alerts if the expression contains spaces.
- Invalid Characters: Indicates if the expression includes characters other than numbers and operators.
- Syntax Errors: Catches errors related to the improper use of arithmetic operators.

### Exiting the Application

To exit the application, simply input `exit` into the console and press `Enter`

## Troubleshooting

- **Application Doesn’t Start** : Ensure you’re in the correct directory and the application file exists.
- **Unexpected Results** : Double-check the expression for syntax accuracy.
- **Error Messages** : Follow the guidance provided in the error message to correct your input.

##  Further Steps to Enhance the Application

- Introduce support for additional arithmetic operations such as exponentiation, parenthesis, modulus, and more complex mathematical functions like trigonometry, logarithms, and square roots.
- Incorporate an in-app help system or documentation access, providing users with guidance on available operations, syntax rules, and examples of expressions.
- Package the application as a standalone executable, making it easily distributable and installable. This may involve making it installable as a command line application.


## Support

For issues or questions regarding the Calculator Console Application, please refer to the application documentation or contact the support team.
