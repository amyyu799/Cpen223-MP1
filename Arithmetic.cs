//MP1 
//This file contains the Arithmethic class.

//You should implement the requesed methods.

using System;
using System.Text;

namespace MP1
{
    public class Arithmetic
    {
        /// <summary>
        /// Use this method as is.
        /// It is called by Main and is used to get an expression from console.
        /// The method calls the EvaluateExpression and OutputExpression methods. 
        /// </summary>
        /// <returns>
        /// A string formed from the formatted expression and the evaluation 
        /// result, or the error message "Invalid expression".
        /// </returns>
        public static string BasicArithmetic()
        {
            Console.WriteLine();
            Console.WriteLine("Basic arithmetic opertions with + - * / ^");
            Console.WriteLine("Enter an expression:");
            string expression = Console.ReadLine().Trim();

            double result = EvaluateExpression(expression);
            if (double.IsNaN(result))
                return "Invalid expression";
            return $"{OutputExpression(expression)} = {result}";
        }

        /// <summary>
        /// Return the numerical evaluation of the arithmetic expression passed to it.
        /// 
        /// Prcedence of the operators (from highest to lowest):
        ///    parenthesis
        ///    power
        ///    multiplication and division (equal precedence)
        ///    addition and subtraction (equal precedence)
        /// An inner parentheses has higher precedence.
        /// * and / have the same precedence.
        /// + and - have the same precedence.
        /// 
        /// All rithmetic operators are left-associative.
        /// 
        /// - can be used as the negative sign as well as subtraction.
        /// There must not be any space between the negative sign and the number.
        /// + is only used for addition (i.e. is not allowed to be used as a positive sign)
        /// </summary>
        /// <param name="expression">
        /// The user input string (with Trim() already applied)
        /// </param>
        /// <returns>
        /// Returns the result of a successful evaluation of the expression,
        /// or double.NaN if the expression is not valid.
        /// </returns>
        /// <example>
        /// If the user expression is "2.1 + 3" or "2.1+ 3" or "2.1 +3", 
        /// then the method returns 5.1
        /// If the user expression is "(8 + -3) * (2 ^ 5)" or "(8 + -3) * 2 ^ 5", 
        /// then the method returns 160 
        /// If the user expression is "2 + ((3 * 2) * 5)" it returns 32 
        /// A 0 before decimal point is not mandatory, so .52 is equivalent to 0.52
        /// Any extra spaces are fine, so if the user enters "  2   ^ 3 ", then 
        /// the method returns 8
        /// If the user input is any incorrect or unbalanced expression, for example,
        /// "4 5" or "4 +" or "+4" or " (4 + 5" or "4 + 5 * 4)", then the method 
        /// returns double.NaN
        /// </example>
        public static double EvaluateExpression(string expression)
        {
            //to implement
        }

        /// <summary>
        /// Returns a modestly cleaned up version of the input expression 
        /// </summary>
        /// <param name="expression">
        /// The user input string (with Trim() already applied)
        /// </param>
        /// <returns>
        /// Returns a string that is rather similar to the expression the user entered, with: 
        /// All extra spaces are removed, but it is ensured that a space is on the either sides of any binary arithmetic operator.
        /// For any negative number being subtracted from another number, it is changed to the addition with its absolute value.
        /// for any negative number being added to another number, it is changed to the subtraction of its absolute value.
        /// </returns>
        /// <example>
        /// If the expression is "2.1 + 3" or "2.1+3" or "2.1+ 3" or "2.1 +3" or "2.1 +    3" 
        ///       then the method returns "2.1 + 3".
        /// If the expression is "2.1 - 3" or "2.1-3" or "2.1- 3" or "2.1 -3" or "2.1 -    3" 
        ///       then the method returns "2.1 - 3".
        /// If the expression is "2.1 + -3" or "2.1+-3" or "2.1 - 3"  
        ///       then the method returns "2.1 - 3".
        /// If the expression is "2.1 - -3" or "2.1--3" or "2.1 + 3"  
        ///       then the method returns "2.1 + 3".
        /// If the expression is "2.1 *   -3" or "2.1*-3"  
        ///       then the method returns "2.1 * -3".
        /// If the expression is "( 2 +  3 )   * 2 ^ 5"
        ///       it returns "(2 + 3) * 2 ^ 5" 
        /// If the expression is "2 + ( ( 3 * 2) *  5)" it returns "2 + ((3 * 2) * 5)" 
        /// Any extra spaces are fine, so if the original user input is "  2   ^ 3 " then 
        ///     the method returns "2 ^ 3".
        /// </example>
        public static string OutputExpression(string expression)
        {
            //to implement
        }

        //You may add helper methods below here. Follow the specs and document well.

    }
}