using System;
using System.Collections.Generic;

public class Calculator<T> where T : struct
{
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

    public T Add(T a, T b)
    {
        AddDelegate add = (x, y) => (dynamic)x + (dynamic)y;
        return add(a, b);
    }

    public T Subtract(T a, T b)
    {
        SubtractDelegate subtract = (x, y) => (dynamic)x - (dynamic)y;
        return subtract(a, b);
    }

    public T Multiply(T a, T b)
    {
        MultiplyDelegate multiply = (x, y) => (dynamic)x * (dynamic)y;
        return multiply(a, b);
    }

    public T Divide(T a, T b)
    {
        if (EqualityComparer<T>.Default.Equals(b, default(T)))
            throw new DivideByZeroException("Division by zero is not allowed.");

        DivideDelegate divide = (x, y) => (dynamic)x / (dynamic)y;
        return divide(a, b);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose the number type for calculations:");
        Console.WriteLine("1. int");
        Console.WriteLine("2. double");
        Console.WriteLine("3. float");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                // Choosing int type
                Calculator<int> intCalculator = new Calculator<int>();
                Console.WriteLine("Enter two numbers (int):");
                int int1 = Convert.ToInt32(Console.ReadLine());
                int int2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Results:");
                Console.WriteLine($"Addition: {intCalculator.Add(int1, int2)}");
                Console.WriteLine($"Subtraction: {intCalculator.Subtract(int1, int2)}");
                Console.WriteLine($"Multiplication: {intCalculator.Multiply(int1, int2)}");
                Console.WriteLine($"Division: {intCalculator.Divide(int1, int2)}");
                break;

            case "2":
                // Choosing double type
                Calculator<double> doubleCalculator = new Calculator<double>();
                Console.WriteLine("Enter two numbers (double):");
                double double1 = Convert.ToDouble(Console.ReadLine());
                double double2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Results:");
                Console.WriteLine($"Addition: {doubleCalculator.Add(double1, double2)}");
                Console.WriteLine($"Subtraction: {doubleCalculator.Subtract(double1, double2)}");
                Console.WriteLine($"Multiplication: {doubleCalculator.Multiply(double1, double2)}");
                Console.WriteLine($"Division: {doubleCalculator.Divide(double1, double2)}");
                break;

            case "3":
                // Choosing float type
                Calculator<float> floatCalculator = new Calculator<float>();
                Console.WriteLine("Enter two numbers (float):");
                float float1 = Convert.ToSingle(Console.ReadLine());
                float float2 = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Results:");
                Console.WriteLine($"Addition: {floatCalculator.Add(float1, float2)}");
                Console.WriteLine($"Subtraction: {floatCalculator.Subtract(float1, float2)}");
                Console.WriteLine($"Multiplication: {floatCalculator.Multiply(float1, float2)}");
                Console.WriteLine($"Division: {floatCalculator.Divide(float1, float2)}");
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}
