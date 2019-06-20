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
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        //function to check missing integer
        public static bool IsMissing(string num){
            for(int i=0; i<num.Length; i++){
                //checking for quetion mark
                if(num[i]=='?')
                    return true;
            }
            return false;
        }
        //function to find ans in case missing integer is a multiplier...
        public static int FindMissingInteger(string missingNumber, string helpingNumber, string realRes, string result, bool flag){
            if(missingNumber.Length == result.Length){
                int len = missingNumber.Length;
                int count = 0, ans = -1;
                //comparing result and the missing number 
                string k = "";
                for(int i = 0; i < len; i++){
                    //counting total unequal digits both numbers 
                    if(missingNumber[i] != result[i]) count++;
                    //checking for question-mark
                    if(missingNumber[i] == '?'){
                        ans = result[i]-'0';
                    }           
                        //generating new value of k after eleminating '?' for calculations            
                    k+=result[i];
                }
                bool b;
                if(flag){
                    //comparing result in case of multiplier digit is missing.
                    b = (int.Parse(k)*int.Parse(helpingNumber) == int.Parse(realRes));
                } else
                {
                    //comparing result in case of results digit is missing.
                     b = int.Parse(helpingNumber) * int.Parse(realRes) == int.Parse(k);
                }
                //returning result if only one digit is unequal and b is true.
                // return -1
                return count == 1 && b ? ans : -1;
            }
            //else return -1.
            return -1;
        }
        public static int FindDigit(string equation)
        {
            string a="", b="", c="";
            int n = equation.Length;
            int i=0;
            //generating first number from equation
            while(i<n && equation[i]!='*'){
                a+=equation[i];
                i++;
            }
            i++;
            //generating second number from equation
            while(i<n && equation[i]!='='){
                b+=equation[i];
                i++;
            }
            i++;
            //generation third number from equation
            while (i<n)
            {
                c+=equation[i];
                i++;
            } 
        
            if(IsMissing(a)){
                string result = (int.Parse(c) / int.Parse(b)).ToString();
                /*
                    passing four parameter to find missing digit 
                    1st - integer whose number is missing
                    2nd - other integer as helping number
                    3rd - required result
                    4th - calculated result
                    5th - flag value to check wether the multiplier missing or result missing
                    flag is true if multiplier is missing.
                    if result is missing than flag is false.               
                 */
                return FindMissingInteger(a, b, c, result, true);    
            }
            else if(IsMissing(b)){
                string result = (int.Parse(c) / int.Parse(a)).ToString();
                return FindMissingInteger(b, a, c, result, true);   
            } else {
                string result = (int.Parse(a) * int.Parse(b)).ToString();
                return FindMissingInteger(c, a, b, result, false);
            }
        }
        
    }
}
