using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigmath
{
  static class BigMathHelper
  {
    /// <summary>
    /// Internal Add Method after numbers already converted.
    /// </summary>
    /// <param name="Num1"></param>
    /// <param name="Num2"></param>
    /// <returns></returns>
    internal static BigMathNumber Add(BigMathNumber Num1, BigMathNumber Num2)
    {
      List<sbyte> retVal = new List<sbyte>();
      //CarryOver = new List<sbyte>();
      List<sbyte> bigger = new List<sbyte>();
      List<sbyte> smaller = new List<sbyte>();
      List<sbyte> answer = new List<sbyte>();

      if (FirstNumberIsBigger(Num1.internalNumber, Num2.internalNumber))
      {
        bigger.AddRange(Num1.internalNumber);
        smaller.AddRange(Num2.internalNumber);
      }
      else
      {
        bigger.AddRange(Num2.internalNumber);
        smaller.AddRange(Num1.internalNumber);
      }

      //add leading zeros to smaller number, if needed.
      while (bigger.Count > smaller.Count)
      {
        smaller.Add(Convert.ToSByte(0));
      }

      //create answer array 1 bigger than biggest number [for carryover]
      for (int i = 0; i < (bigger.Count + 1); i++)
      {
        answer.Add(Convert.ToSByte(0));
      }

      sbyte curNum = 0;

      for (int i = 0; i < bigger.Count; i++)
      {
        curNum = Convert.ToSByte(bigger[i] + smaller[i]);
        if (curNum >= 10)
        {
          curNum -= 10;
          CarryOverFrom(bigger, 1, i);
          while (bigger.Count > smaller.Count) //add another point to the smaller number, if needed at this point.
          {
            smaller.Add(0);
          }
        }
        while (bigger.Count > answer.Count)
        {
          answer.Add(0); //add leading zeros, when needed.
        }
        answer[i] = curNum;
      }

      retVal.AddRange(answer);
      BigMathNumber answerNumber = new BigMathNumber();
      answerNumber.internalNumber = retVal;
      return answerNumber;
    }

    /// <summary>
    /// Add Version of carry over, it actually adds the carry over to the number's next position
    /// </summary>
    /// <param name="number"></param>
    /// <param name="numberToCarryOver"></param>
    /// <param name="positionFrom"></param>
    private static void CarryOverFrom(List<sbyte> number, sbyte numberToCarryOver, int positionFrom)
    {
      if (number.Count < positionFrom + 2)
      {
        number.Add(numberToCarryOver); //add new larger number position
      }
      else
      {
        number[positionFrom + 1] += numberToCarryOver;
      }
    }

    private static bool FirstNumberIsBigger(List<sbyte> FirstNumber, List<sbyte> SecondNumber)
    {
      bool retVal = true; // assume equal, which is technically bigger for this math =)

      //remove leading zeros from both numbers
      while (FirstNumber.Last() == 0 && FirstNumber.Count > 1)
      {
        FirstNumber.RemoveAt(FirstNumber.Count - 1);
      }
      while (SecondNumber.Last() == 0 && SecondNumber.Count > 1)
      {
        SecondNumber.RemoveAt(SecondNumber.Count - 1);
      }

      if (FirstNumber.Count > SecondNumber.Count) //num 1 larger
      {
        retVal = true;
      }
      else if (FirstNumber.Count == SecondNumber.Count)
      {
        //loop through each number trying to determine which number is larger. 
        //from largest number to lowest
        for (int i = FirstNumber.Count - 1; i >= 0; i--)
        {
          if (FirstNumber[i] > SecondNumber[i])
          {
            retVal = true;
            break;
          }
          else if (FirstNumber[i] < SecondNumber[i])
          {
            retVal = false;
            break;
          }
          //otherwise numbers match, keep looking
        }
      }
      else
      {
        retVal = false; //second number has larger count
      }

      return retVal;
    }

    /// <summary>
    /// Internal Subtract when we've already changed the string values into List Arrays.
    /// </summary>
    /// <param name="Num1"></param>
    /// <param name="Num2"></param>
    /// <returns></returns>
    internal static BigMathNumber Subtract(BigMathNumber Num1, BigMathNumber Num2)
    {
      List<sbyte> retVal = new List<sbyte>();
      List<sbyte> bigger = new List<sbyte>();
      List<sbyte> smaller = new List<sbyte>();
      List<sbyte> answer = new List<sbyte>();

      if (FirstNumberIsBigger(Num1.internalNumber, Num2.internalNumber))
      {
        //copy to new array
        bigger.AddRange(Num1.internalNumber);
        smaller.AddRange(Num2.internalNumber);
      }
      else
      {
        bigger.AddRange(Num2.internalNumber);
        smaller.AddRange(Num1.internalNumber);
      }

      //build answer array [same size as 'bigger' number]
      for (int i = 0; i < bigger.Count; i++)
      {
        answer.Add(Convert.ToSByte(0));
      }

      //add leading zeros to smaller number, if needed.
      while (bigger.Count > smaller.Count)
      {
        smaller.Add(Convert.ToSByte(0));
      }

      //perform subtraction
      for (int i = 0; i < bigger.Count; i++)
      {
        //loop through each column at the same time

        if (bigger[i] >= smaller[i])//top larger or equal
        {
          answer[i] = Convert.ToSByte(bigger[i] - smaller[i]);
        }
        else //need to borrow before math
        {
          if (BorrowAt(bigger, i))
          {
            answer[i] = Convert.ToSByte(bigger[i] - smaller[i]); //should always be allowed to do this.
          }
        }
      }

      //remove leading zeros, if any [down to last item]
      while ((answer.Last() == Convert.ToSByte(0)) && (answer.Count > 1))
      {
        answer.RemoveAt(answer.Count - 1);
      }

      retVal.AddRange(answer);
      BigMathNumber answerNumber = new BigMathNumber();
      answerNumber.internalNumber = answer;

      return answerNumber;
    }

    private static bool BorrowAt(List<sbyte> number, int positionneeding)
    {
      bool retVal = false; //assume failure
      if (number.Count >= (positionneeding + 1))
      {
        if (number.ElementAt(positionneeding + 1) == 0)
        {
          //borrow to the next number?
          if (BorrowAt(number, positionneeding + 1))
          {
            number[positionneeding + 1] = 9; //reduce 10 to 9
            number[positionneeding] += 10; //add that borrow to the position needing it.
            retVal = true;
          }
          else //can't borrow anything
          {
            throw new ArgumentOutOfRangeException();
          }
        }
        else
        {
          //reduce the number and return the carry over to the calling item.
          number[positionneeding + 1] = Convert.ToSByte(number[positionneeding + 1] - Convert.ToSByte(1));
          number[positionneeding] = Convert.ToSByte(number[positionneeding] + Convert.ToSByte(10));
          retVal = true;
        }
      } // else - nothing to borrow
      return retVal;
    }



  }
}
