using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbersTDD.Business
{
    public class RomanNumbers
    {
        private readonly Dictionary<char, int> numbers = new Dictionary<char, int>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RomanNumbers()
        {
            numbers.Add('I', 1);
            numbers.Add('V', 5);
            numbers.Add('X', 10);
            numbers.Add('L', 50);
            numbers.Add('C', 100);
            numbers.Add('D', 500);
            numbers.Add('M', 1000);
        }

        /// <summary>
        /// Converts the roman numbers to integer numbers
        /// </summary>
        /// <param name="romanNumber"></param>
        /// <returns></returns>
        public int Convert(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber) || string.IsNullOrWhiteSpace(romanNumber))
            {
                throw new ArgumentException();
            }

            int sum = 0;
            for (int i = 0; i < romanNumber.Length; i++)
            {
                int numberZero = GetValue(romanNumber[i]);
                int numberOne = i + 1 < romanNumber.Length ? GetValue(romanNumber[i + 1]) : -1;
                if (numberOne == -1)
                {
                    sum += numberZero;
                }
                else if (numberZero >= numberOne)
                {
                    sum += numberZero;
                }
                else if (numberZero < numberOne)
                {
                    sum += numberOne - numberZero;
                    i++;
                }
            }
            return sum;
        }

        public int GetValue(char key)
        {
            if (numbers.TryGetValue(key, out int value))
                return value;
            else
                throw new InvalidOperationException();
        }
    }
}
