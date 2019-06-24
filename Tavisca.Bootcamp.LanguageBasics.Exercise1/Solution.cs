
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Solution
    {
        public static int FindMissingInteger(string missingNumber, string helpingNumber, string requiredResult, string assumedResult, bool isMultiplierMissing)
        {
            if (missingNumber.Length == assumedResult.Length)
            {
                int len = missingNumber.Length;
                int count = 0, ans = -1;
                //comparing result and the missing number 
                string tempResult = "";
                for (int i = 0; i < len; i++)
                {
                    //counting total unequal digits both numbers 
                    if (missingNumber[i] != assumedResult[i]) count++;
                    //checking for question-mark
                    if (missingNumber[i] == '?')
                    {
                        ans = assumedResult[i] - '0';
                    }
                    //generating new value of k after eleminating '?' for calculations            
                    tempResult += assumedResult[i];
                }
                bool flag;
                if (isMultiplierMissing)
                {
                    //comparing result in case of multiplier digit is missing.
                    flag = (int.Parse(tempResult) * int.Parse(helpingNumber) == int.Parse(requiredResult));
                }
                else
                {
                    //comparing result in case of results digit is missing.
                    flag = int.Parse(helpingNumber) * int.Parse(requiredResult) == int.Parse(tempResult);
                }
                //returning result if only one digit is unequal and b is true.
                // return -1
                return count == 1 && flag ? ans : -1;
            }
            //else return -1.
            return -1;
        }


    }
    
}