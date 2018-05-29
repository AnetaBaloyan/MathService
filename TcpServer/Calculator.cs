using System;

namespace MathServer
{
    /// <summary>
    /// The calculator service.
    /// </summary>
    public class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Sub(double a, double b)
        {
            return a - b;
        }

        public static double Div(double a, double b)
        {
            return a / b;
        }

        public static double Mult(double a, double b)
        {
            return a * b;
        }

        public static string Handle(string msg)
        {
            if (msg.Contains("*"))
            {
                string[] arr = msg.Split('*');
                return (Mult(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
            }
            else if (msg.Contains("+"))
            {
                string[] arr = msg.Split('+');
                return (Add(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
            }
            else if (msg.Contains("-"))
            {
                string[] arr = msg.Split('-');
                return (Sub(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
            }
            else if (msg.Contains("/"))
            {
                string[] arr = msg.Split('/');
                return (Div(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
            }
            else
                return "Invalid operation. The protocol is number_operator_number.";
        }
    }
}
