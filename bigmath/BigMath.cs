using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigmath
{
    public static class BigMath //: IBigMath
    {

      /// <summary>
      /// Returns the Sum of Left + Right
      /// </summary>
      /// <param name="Left"></param>
      /// <param name="Right"></param>
      /// <returns></returns>
      public static String Add(String Left, String Right)
      {
        var leftNumber = new BigMathNumber();
        var rightNumber = new BigMathNumber();
        leftNumber.SetValue(Left);
        rightNumber.SetValue(Right);

        var answer = leftNumber + rightNumber;

        var answerResponse = answer.ToString();
        return answerResponse; 
      }

      /// <summary>
      /// Returns Difference of Left - Right
      /// </summary>
      /// <param name="Left"></param>
      /// <param name="Right"></param>
      /// <returns></returns>
      public static String Subtract(String Left, String Right)
      {
        var leftNumber = new BigMathNumber();
        var rightNumber = new BigMathNumber();
        leftNumber.SetValue(Left);
        rightNumber.SetValue(Right);

        var answer = leftNumber - rightNumber;

        var answerResponse = answer.ToString();
        return answerResponse;
      }

      /// <summary>
      /// Returns the Product of Left * Right
      /// </summary>
      /// <param name="Left"></param>
      /// <param name="Right"></param>
      /// <returns></returns>
      public static String Multiply(String Left, String Right)
      {
        var leftNumber = new BigMathNumber();
        var rightNumber = new BigMathNumber();
        leftNumber.SetValue(Left);
        rightNumber.SetValue(Right);

        var answer = leftNumber * rightNumber;

        var answerResponse = answer.ToString();
        return answerResponse;
      }

      /// <summary>
      /// Returns quotient of Dividend / Devisor
      /// </summary>
      /// <param name="Dividend"></param>
      /// <param name="Devisor"></param>
      /// <returns></returns>
      public static String Divide(String Dividend, String Devisor)
      {
        var leftNumber = new BigMathNumber();
        var rightNumber = new BigMathNumber();
        leftNumber.SetValue(Dividend);
        rightNumber.SetValue(Devisor);

        var answer = leftNumber / rightNumber;

        var answerResponse = answer.ToString();
        return answerResponse;
      }

      /// <summary>
      /// Returns the Factoral of Number
      /// </summary>
      /// <param name="Number"></param>
      /// <returns></returns>
      public static String Factorial(String Number)
      {
        var valueNumber = new BigMathNumber();
        valueNumber.SetValue(Number);
        var answer = BigMathHelper.Factorial(valueNumber);
        var returnValue = answer.ToString();
        return returnValue;
      }

      /// <summary>
      /// Returns the result of BaseNumber^Exponent
      /// </summary>
      /// <param name="BaseNumber"></param>
      /// <param name="Exponent"></param>
      /// <returns></returns>
      public static String Exponential(String BaseNumber, String Exponent)
      {
        string RetVal = String.Empty;
        return RetVal;
      }
    }
}
