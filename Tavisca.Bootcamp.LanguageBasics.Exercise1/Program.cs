using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            // Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        //function to find ans in case missing integer is a multiplier...
        public static int FindDigit(string equation)
        {
            
            string[] temp = equation.Split("*");
            string firstNumber = temp[0];
            string secondNumber = temp[1].Split("=")[0];
            string thirdNumber = temp[1].Split("=")[1];

            if(firstNumber.Contains("?")){
                string result = (int.Parse(thirdNumber) / int.Parse(secondNumber)).ToString();
                return Solution.FindMissingInteger(firstNumber, secondNumber, thirdNumber, result, true);    
            }
            else if(secondNumber.Contains("?")){
                string result = (int.Parse(thirdNumber) / int.Parse(firstNumber)).ToString();
                return Solution.FindMissingInteger(secondNumber, firstNumber, thirdNumber, result, true);   
            } else {
                string result = (int.Parse(firstNumber) * int.Parse(secondNumber)).ToString();
                return Solution.FindMissingInteger(thirdNumber, firstNumber, secondNumber, result, false);
            }
        }
        
    }
}
