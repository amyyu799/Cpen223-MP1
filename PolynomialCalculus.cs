//MP1  
//This file contains the PolynomialCalculus class.

//You should implement the requesed methods.


using System;
using System.Collections.Generic;
using System.Text;

namespace MP1
{
    public class PolynomialCalculus
    {
        List<double> coefficientList = new List<double>(); //the only field of this class

        // The following two constructors are used for unit testing.
        public PolynomialCalculus() //Needed for unit testing and for Main(). Do not remove or modify.
        {
            // Default constructor has an empty body
        }
        public PolynomialCalculus(string testInput) //Needed for unit testing. Do not remove or modify.
        {
            string[] coefficients = testInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in coefficients)
            {
                coefficientList.Add(Convert.ToDouble(item));
            }
        }

        /// <summary>
        /// Prompts the user for the coefficients of a polynomial, and sets the 
        /// the coefficientList field of the object.
        /// The isValidPolynomial method is used to check for the validity
        /// of the polynomial entered by the user, otherwise the field must 
        /// not change.
        /// The acceptable format of the coefficients received from the user is 
        /// a series of numbers (one for each coefficient) separated by spaces.
        /// All coefficients values must be entered even those that are zero.
        /// </summary>
        /// <returns>True if the polynomial is succeffully set, false otherwise.</returns>
        public bool SetPolynomial()
        {
            Console.WriteLine("\nEnter the coeficients for the polynomial, separated by a space (descending order).");
            Console.WriteLine("Example: Enter 1.13 0 -3 1 0 for the polynomial 1.13x^4 - 3x^2 + x");
            string coefficientEntry = Console.ReadLine().Trim();

            //to implement
        }

        /// <summary>
        /// Checks if the passed polynomial string is valid.
        /// The acceptable format of the coefficient string is a series of 
        /// numbers (one for each coefficient) separated by spaces. 
        /// Any number of extra spaces is allowed.
        /// </summary>
        /// <example>
        /// Examples of valid strings: 
        ///       "1 2 3", or " 2   3.5 0  ", or "-2 -3.547 0 0", or "0 .1 -1"
        /// Examples of invalid strings: 
        ///       "3 . 5", or "2x^2+1", or "a b c", or "3 - 5", or "1/2 2", or ""
        /// </example>
        /// <param name="polynomial">
        /// A string containing the coefficient of a polynomial. The first value is the
        /// highest order, and all coefficients exist (even 0's).
        /// </param>
        /// <returns>True if a valid polynomial, false otherwise.</returns>
        public bool IsValidPolynomial(string polynomial)
        {
            //to implement
        }

        /// <summary>
        /// Returns a string representing this polynomial.
        /// </summary>
        /// <returns>
        /// A string containing the polynomial in the format:
        /// a_nx^n +- a_n_1x^n_1 +- ... +- a1x +- a0
        /// Formatting rules:
        /// The +- operator will be + if the associated coefficient is positive, and - if negative.
        /// There is a space on either side of the binary operator.
        /// Do not display the associated term of a coefficient if it is 0.
        /// Do not display a coefficient if it is 1, except for a0.
        /// Do not display the power of x, if it is 1.
        /// If all coefficients are 0, then it returns "0".
        /// <example>
        /// For a user input "1 1 1", the method returns "x^2 + x + 1"
        /// For a user input "-1 -1 -1", the method returns "-x^2 - x - 1"
        /// For a user input "3 2 1", the method returns "3x^2 + 2x + 1"
        /// For a user input "0", the method returns "0"
        /// For a user input "-123.456", the method returns "-123.456"
        /// For a user input "-1.3 0 -5", the method returns "-1.3x^2 - 5"
        /// For a user input "0 0 -.55 13 0", the method returns "-0.55x^2 + 13x"
        /// For a user input "1 0 -2.1 -1 5 12", the method returns "x^5 - 2.1x^3 - x^2 + 5x + 12"
        /// </example>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public string GetPolynomial()
        {
            //to implement
        }

        /// <summary>
        /// Evaluates this polynomial at the x passed to the method.
        /// </summary>
        /// <param name="x">The x at which we are evaluating the polynomial.</param>
        /// <returns>The result of the polynomial evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomial(double x)
        {
            //to implement
        }

        /// <summary>
        /// Finds a root of this polynomial using the provided guess.
        /// </summary>
        /// <param name="guess">The initial value for the Newton method.</param>
        /// <param name="epsilon">The desired accuracy: stops when |f(result)| is
        /// less than or equal epsilon.</param>
        /// <param name="iterationMax">A max cap on the number of iterations in the
        /// Newton-Raphson method. This is to also guarantee no infinite loops.
        /// If this iterationMax is reached, a double.NaN is returned.</param>
        /// <returns>
        /// The root found using the Netwon-Raphson method. 
        /// A double.NaN is returned if a root cannot be found.
        /// The return value is rounded to have 4 digits after the decimal point.
        /// </returns>
        public double NewtonRaphson(double guess, double epsilon, int iterationMax)
        {
            int count;
            double x = guess;

            for (count = 0; Math.Abs(EvaluatePolynomial(x)) > epsilon && count < iterationMax; count++)
            {
                x -= EvaluatePolynomial(x) / EvaluatePolynomialDerivative(x);
            }

            if (count == iterationMax)
            {
                return double.NaN;
            }

            return Math.Round(x, 4); //4 decimal places
        }

        /// <summary>
        /// Calculates and returns all unique real roots of this polynomial 
        /// that can be found using the NewtonRaphson method. 
        /// The method uses all initial guesses between -50 and 50 (inclusive) with 
        /// steps of 0.5 to find all unique roots it can find. 
        /// A root is considered unique, if there is no root already found 
        /// that is within an accuracy level of 0.001 (since we rounded the roots).
        /// Uses 10 as the max number of iterations used by Newton-Raphson method.
        /// </summary>
        /// <param name="epsilon">The desired accuracy used for NewtonRaphson.</param>
        /// <returns>A list containing all the unique roots that the method finds.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty. 
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public List<double> GetAllRoots(double epsilon)
        {
            //to implement
        }

        /// <summary>
        /// Evaluates the 1st derivative of this polynomial at x (passed to the method).
        /// The method uses the exact numerical technique, since it is easy to obtain the 
        /// derivative of a polynomial.
        /// </summary>
        /// <param name="x">The x at which we are evaluating the polynomial derivative.</param>
        /// <returns>The result of the polynomial derivative evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty.
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomialDerivative(double x)
        {
            //to implement
        }

        /// <summary>
        /// Evaluates the definite integral of this polynomial from a to b.
        /// The method uses the exact numerical technique, since it is easy to obtain the 
        /// indefinite integral of a polynomial.
        /// </summary>
        /// <param name="a">The lower limit of the integral.</param>
        /// <param name="b">The upper limit of the integral.</param>
        /// <returns>The result of the integral evaluation.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the coefficientList field is empty.
        /// Exception message used: "No polynomial is set."
        /// </exception>
        public double EvaluatePolynomialIntegral(double a, double b)
        {
            //to implement
        }
    }
}
