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
    /// <param name="Left"></param>
    /// <param name="Right"></param>
    /// <returns></returns>
    internal static BigMathNumber Add(BigMathNumber Left, BigMathNumber Right)
    {
      List<sbyte> left = Left.internalNumber;
      List<sbyte> right = Right.internalNumber;
      List<sbyte> answer = Add(left, right);

      BigMathNumber theAnswer = new BigMathNumber();
      theAnswer.internalNumber = answer;
      return theAnswer;
    }

    /// <summary>
    /// Internal Add Method after numbers already converted.
    /// </summary>
    /// <param name="Num1"></param>
    /// <param name="Num2"></param>
    /// <returns></returns>
    private static List<sbyte> Add(List<sbyte> Num1, List<sbyte> Num2)
    {
      List<sbyte> retVal = new List<sbyte>();
      //CarryOver = new List<sbyte>();
      List<sbyte> bigger = new List<sbyte>();
      List<sbyte> smaller = new List<sbyte>();
      List<sbyte> answer = new List<sbyte>();

      if (FirstNumberIsBigger(Num1, Num2))
      {
        bigger.AddRange(Num1);
        smaller.AddRange(Num2);
      }
      else
      {
        bigger.AddRange(Num2);
        smaller.AddRange(Num1);
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
      return retVal;
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
    /// <param name="Left"></param>
    /// <param name="Right"></param>
    /// <returns></returns>
    internal static BigMathNumber Subtract(BigMathNumber Left, BigMathNumber Right)
    {
      List<sbyte> left = Left.internalNumber;
      List<sbyte> right = Right.internalNumber;
      List<sbyte> answer = Subtract(left, right);

      BigMathNumber theAnswer = new BigMathNumber();
      theAnswer.internalNumber = answer;
      return theAnswer;
    }

    private static List<sbyte> Subtract(List<sbyte> Num1, List<sbyte> Num2)
    {
      List<sbyte> retVal = new List<sbyte>();
      List<sbyte> bigger = new List<sbyte>();
      List<sbyte> smaller = new List<sbyte>();
      List<sbyte> answer = new List<sbyte>();

      if (FirstNumberIsBigger(Num1, Num2))
      { 
        //copy to new array
        bigger.AddRange(Num1);
        smaller.AddRange(Num2);
      }
      else
      {
        bigger.AddRange(Num2);
        smaller.AddRange(Num1);
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
      return retVal;
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

    /// <summary>
    /// Multiply Method will multiply two numbers together returning as a BigMathNumber
    /// </summary>
    /// <param name="Left"></param>
    /// <param name="Right"></param>
    /// <returns></returns>
    internal static BigMathNumber Multiply(BigMathNumber Left, BigMathNumber Right)
    {
      List<sbyte> left = Left.internalNumber;
      List<sbyte> right = Right.internalNumber;
      List<sbyte> answer = Multiply(left, right);

      BigMathNumber theAnswer = new BigMathNumber();
      theAnswer.internalNumber = answer;
      return theAnswer;
    }

    private static List<sbyte> Multiply(List<sbyte> num1, List<sbyte> num2)
    {
      List<sbyte> retVal = new List<sbyte>();
      List<sbyte> curAns = new List<sbyte>();
      List<sbyte> curRow = new List<sbyte>();
      List<sbyte> carry = new List<sbyte>();
      List<sbyte> bigger = new List<sbyte>();
      List<sbyte> smaller = new List<sbyte>();

      if (FirstNumberIsBigger(num1, num2))
      {
        bigger.AddRange(num1);
        smaller.AddRange(num2);
      }
      else
      {
        bigger.AddRange(num2);
        smaller.AddRange(num1);
      }

      //build up an answer
      while (bigger.Count + 3 > curAns.Count)
      {
        curAns.Add(0);
      }

      //build up carry over
      while (bigger.Count + 3 > carry.Count)
      {
        carry.Add(0);
      }

      sbyte curNum = 0;

      for (int i = 0; i < smaller.Count; i++)
      {
        //reset carryover for new number
        for (int p = 0; p < carry.Count; p++)
        {
          carry[p] = 0;
        }
        //reset the current Row for new math
        for (int q = 0; q < curRow.Count; q++)
        {
          curRow[q] = 0;
        }
        for (int x = 0; x < bigger.Count; x++)
        {
          curNum = Convert.ToSByte(smaller[i] * bigger[x]);
          if (curNum > 10)
          {
            addToCarryOver(carry, Convert.ToSByte(curNum / 10), (x + i));
            curNum = Convert.ToSByte(curNum % 10);
          }
          while (curRow.Count < (x + i) + 1)
          {
            curRow.Add(0);
          }
          curRow[x + i] = curNum;
        }
        //add in the carry over to the current Row [don't forget that we can still have a carry over here]
        while (curRow.Count < (carry.Count + 1))
        {
          curRow.Add(0);
        }
        for (int e = 0; e < carry.Count; e++)
        {
          if ((curRow[e] + carry[e]) > 10)
          {
            curRow[e] = Convert.ToSByte(curRow[e] + (carry[e] - 10));
            curRow[e + 1] = Convert.ToSByte(curRow[e + 1] + 1);
          }
          else
          {
            curRow[e] += carry[e];
          }
        }
        curAns = Add(curAns, curRow);
      }
      retVal.AddRange(curAns);
      return retVal;
    }

    private static void addToCarryOver(List<sbyte> carryList, sbyte amountToCarryOver, int positionFrom)
    {
      while (carryList.Count < positionFrom + 2)
      {
        carryList.Add(0);
      }
      carryList[positionFrom + 1] = amountToCarryOver;
    }

    internal static BigMathNumber Factorial(BigMathNumber Value)
    {
      List<sbyte> value = Value.internalNumber;
      List<sbyte> answer = Factorial(value);

      BigMathNumber theAnswer = new BigMathNumber();
      theAnswer.internalNumber = answer;
      return theAnswer;
    }

    private static List<sbyte> Factorial(List<sbyte> Number)
    {
      List<sbyte> retVal = new List<sbyte>();
      List<sbyte> curNum = new List<sbyte>();
      curNum.AddRange(Number);
      List<sbyte> decrementor = new List<sbyte>();
      decrementor.Add(Convert.ToSByte(1));

      List<sbyte> answer = new List<sbyte>();

      answer.AddRange(curNum); //copy curNum to answer
      curNum = Subtract(curNum, decrementor);
      while (FirstNumberIsBigger(curNum, decrementor))
      {
        answer = Multiply(answer, curNum);
        curNum = Subtract(curNum, decrementor);
      }

      retVal.AddRange(answer);
      return retVal;
    }

    internal static BigMathNumber Exponential(BigMathNumber BaseNumber, BigMathNumber Exponent)
    {
      List<sbyte> baseNumber = BaseNumber.internalNumber;
      List<sbyte> exponent = Exponent.internalNumber;
      List<sbyte> answer = Exponential(baseNumber, exponent);

      BigMathNumber theAnswer = new BigMathNumber();
      theAnswer.internalNumber = answer;
      return theAnswer;
    }

    private static List<sbyte> Exponential(List<sbyte> BaseNumber, List<sbyte> Exponent)
    {
      List<sbyte> retVal = new List<sbyte>();
      List<sbyte> testVal = new List<sbyte>();
      List<sbyte> exponent = new List<sbyte>();
      exponent.AddRange(Exponent);
      testVal.Add(0);
      List<sbyte> decrementor = new List<sbyte>();
      decrementor.Add(1);
      List<sbyte> curAns = new List<sbyte>();

      curAns.Add(1);
      while ((exponent.Count > 1) || (exponent.Last() != 0 && (exponent.Count == 1)))
      {
        curAns = Multiply(curAns, BaseNumber);
        exponent = Subtract(exponent, decrementor);
      }
      retVal.AddRange(curAns);
      return retVal;
    }


  }
}
