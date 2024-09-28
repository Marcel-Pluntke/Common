//This is an CheatSheet for C# Programming Language.
//This CheatSheet is created by Marcel Pluntke in C#

//numeric data types
//byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal

// print out all data types, with there min and max values
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Types");
            Console.WriteLine("byte: {0} to {1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("sbyte: {0} to {1}", sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("short: {0} to {1}", short.MinValue, short.MaxValue);
            Console.WriteLine("ushort: {0} to {1}", ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("int: {0} to {1}", int.MinValue, int.MaxValue);
            Console.WriteLine("uint: {0} to {1}", uint.MinValue, uint.MaxValue);
            Console.WriteLine("long: {0} to {1}", long.MinValue, long.MaxValue);
            Console.WriteLine("ulong: {0} to {1}", ulong.MinValue, ulong.MaxValue);
            Console.WriteLine("float: {0} to {1}", float.MinValue, float.MaxValue);
            Console.WriteLine("double: {0} to {1}", double.MinValue, double.MaxValue);
            Console.WriteLine("decimal: {0} to {1}", decimal.MinValue, decimal.MaxValue);

            Console.ReadLine();

            Console.WriteLine("Aritmetic Operators");

            int a = 10;
            int b = 3;
            Console.WriteLine("a: {0} b: {1}", a, b);
            Console.WriteLine("Addition: {0}", a + b);
            Console.WriteLine("Subtraction: {0}", a - b);
            Console.WriteLine("Multiplication: {0}", a * b);
            Console.WriteLine("Division: {0}", a / b);
            Console.WriteLine("Modulus: {0}", a % b);

            Console.ReadLine();

            Console.WriteLine("Comparison Operators");
            Console.WriteLine("a: {0} b: {1}", a, b);
            Console.WriteLine("a > b: {0}", a > b);
            Console.WriteLine("a < b: {0}", a < b);
            Console.WriteLine("a >= b: {0}", a >= b);
            Console.WriteLine("a <= b: {0}", a <= b);
            Console.WriteLine("a == b: {0}", a == b);
            Console.WriteLine("a != b: {0}", a != b);

            Console.ReadLine();

            Console.WriteLine("Logical Operators");
            Console.WriteLine("a: {0} b: {1}", a, b);
            Console.WriteLine("a > 5 && b > 5: {0}", a > 5 && b > 5);
            Console.WriteLine("a > 5 || b > 5: {0}", a > 5 || b > 5);
            Console.WriteLine("!(a > 5): {0}", !(a > 5));

            Console.ReadLine();

            Console.WriteLine("Bitwise Operators");
            Console.WriteLine("a: {0} b: {1}", a, b);
            Console.WriteLine("a & b: {0}", a & b);
            Console.WriteLine("a | b: {0}", a | b);
            Console.WriteLine("a ^ b: {0}", a ^ b);
            Console.WriteLine("~a: {0}", ~a);
            Console.WriteLine("a << 2: {0}", a << 2);
            Console.WriteLine("a >> 2: {0}", a >> 2);

            Console.ReadLine();

            Console.WriteLine("Assignment Operators");
            Console.WriteLine("a: {0} b: {1}", a, b);
            Console.WriteLine("a += b: {0}", a += b);
            Console.WriteLine("a -= b: {0}", a -= b);
            Console.WriteLine("a *= b: {0}", a *= b);
            Console.WriteLine("a /= b: {0}", a /= b);
            Console.WriteLine("a %= b: {0}", a %= b);
            Console.WriteLine("a &= b: {0}", a &= b);
            Console.WriteLine("a |= b: {0}", a |= b);
            Console.WriteLine("a ^= b: {0}", a ^= b);
            Console.WriteLine("a <<= 2: {0}", a <<= 2);
            Console.WriteLine("a >>= 2: {0}", a >>= 2);

            Console.ReadLine();

            Console.WriteLine("Console Print and Read");
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);
            
            // add inputs in an  array and sort it and print it out
            Console.WriteLine("Enter 5 numbers: ");
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(numbers);
            Console.WriteLine("Sorted Numbers: ");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // input 5 strings and sort all "a" and "e" 
            Console.WriteLine("Enter 5 strings: ");
            string[] strings = new string[5];
            for (int i = 0; i < 5; i++)
            {
                strings[i] = Console.ReadLine();
            }
            List<string> aeStrings = new List<string>();
            foreach (string str in strings)
            {
                if (str.Contains("a") || str.Contains("e"))
                {
                    aeStrings.Add(str);
                }
            }
            Console.WriteLine("Strings with a or e: ");
            foreach (string str in aeStrings)
            {
                Console.WriteLine(str);
            }

            //remove all "a" and "e" from the strings and print out the result, Also check for capital letters. Take the String array from the previous example
            List<string> noAeStrings = new List<string>();
            foreach (string str in strings)
            {
                string newStr = str.Replace("a", "").Replace("e", "").Replace("A", "").Replace("E", "");
                noAeStrings.Add(newStr);
            }
            Console.WriteLine("Strings without a or e: ");
            foreach (string str in noAeStrings)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();

        }
    }
}