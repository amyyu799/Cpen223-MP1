//MP1
//This file contains the Program class with the Main method.

//You should not change this file. Please use as is.

using System;
using System.Collections.Generic;

namespace MP1
{
    public class Program
    {
        static void Main()
        {
            PolynomialCalculus calculator = new PolynomialCalculus();

            Console.WriteLine("Welcome to the program! Select from the menu:");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Arithmetic: (e)nter expression to evaluate");
                Console.WriteLine("Polynomial calculus: (s)et coefficients, (d)ifferentiate, (i)ntegrate, (g)et roots, (p)rint polynomial");
                Console.Write("Your choice (q to quit): ");
                string userInput;

                try
                {
                    userInput = Console.ReadLine().Trim().ToLower();
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine($"IO Exception: {e.Message}");
                    continue;
                }

                string result = "Not a valid polynomial.";
                const double accuracy = 0.000001; //For simplcity, accuracy is set to a constant.

                if (userInput.Length == 0) continue; //in case userInput is empty (whitespace or just enter)

                if (userInput.StartsWith('q')) break; //(q)uit

                char choice = userInput[0];

                switch (choice)
                {
                    case 'e':         //(e)nter expression
                        result = Arithmetic.BasicArithmetic();
                        break;
                    case 's':        //(s)et coefficients
                        try
                        {
                            if (calculator.SetPolynomial())
                            {
                                result = $"Polynomial saved successfully: {calculator.GetPolynomial()}";
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            result = e.Message;
                        }
                        break;
                    case 'd':       //(d)ifferentiate
                        result = Derivative(calculator);
                        break;
                    case 'i':       //(i)ntegrate
                        result = Integral(calculator);
                        break;
                    case 'g':       //(g)et roots
                        try
                        {
                            List<double> roots = calculator.GetAllRoots(accuracy);
                            if (roots.Count == 0)
                            {
                                result = "No real roots found.";
                            }
                            else
                            {
                                result = string.Empty;
                                for (int i = 0; i < roots.Count; i++)
                                {
                                    result += $"root{i} = {roots[i]}\n";
                                }
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            result = e.Message;
                        }
                        break;
                    case 'p':         //(p)rint polynomial
                        try
                        {
                            result = calculator.GetPolynomial();
                        }
                        catch (InvalidOperationException e)
                        {
                            result = e.Message;
                        }
                        break;
                    default:
                        result = "Please choose from the menu";
                        break;
                }
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }
        static string Derivative(PolynomialCalculus calculator)
        {
            string result;

            try
            {
                Console.WriteLine();
                Console.Write($"Calculating derivative of {calculator.GetPolynomial()} evaluated at what x? ");
            }
            catch (InvalidOperationException e)
            {
                return e.Message;
            }

            if (double.TryParse(Console.ReadLine().Trim(), out double x))
            {
                try
                {
                    result = $"result = {calculator.EvaluatePolynomialDerivative(x)}";
                }
                catch (InvalidOperationException e)
                {
                    result = e.Message;
                }
            }
            else
            {
                result = "Not a valid number";
            }

            return result;
        }
        static string Integral(PolynomialCalculus calculator)
        {
            string result;

            try
            {
                Console.WriteLine();
                Console.WriteLine($"Calculating integral of {calculator.GetPolynomial()} from a to b.");
            }
            catch (InvalidOperationException e)
            {
                return e.Message;
            }

            Console.Write("What is a? ");
            if (!double.TryParse(Console.ReadLine().Trim(), out double a))
            {
                result = "Not a valid number.";
            }
            else
            {
                Console.Write("What is b? ");
                if (!double.TryParse(Console.ReadLine().Trim(), out double b))
                {
                    result = "Not a valid number.";
                }
                else
                {
                    try
                    {
                        result = $"result = {calculator.EvaluatePolynomialIntegral(a, b)}";
                    }
                    catch (InvalidOperationException e)
                    {
                        result = e.Message;
                    }
                }
            }
            return result;
        }
    }
}
