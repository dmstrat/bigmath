using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigmath
{
  internal class BigMathNumber :  IEquatable<BigMathNumber>
  {
    public List<sbyte> internalNumber {get;set;}

    public BigMathNumber()
    {
      Initialize();
    }

    private void Initialize()
    {
      internalNumber = new List<sbyte>();
      sbyte newNumber = 0;
      internalNumber.Add(newNumber); //init as zero
    }

    public static BigMathNumber operator +(BigMathNumber left, BigMathNumber right)
    {
      BigMathNumber answer = new BigMathNumber();
      answer = BigMathHelper.Add(left, right);
      return answer;
    }

    public static BigMathNumber operator -(BigMathNumber left, BigMathNumber right)
    {
      BigMathNumber answer = new BigMathNumber();
      answer = BigMathHelper.Subtract(left,right);
      return answer;
    }

    public static BigMathNumber operator *(BigMathNumber left, BigMathNumber right)
    {
      BigMathNumber answer = new BigMathNumber();

      return answer;
    }

    public static BigMathNumber operator /(BigMathNumber left, BigMathNumber right)
    {
      BigMathNumber answer = new BigMathNumber();

      return answer;
    }

    public static bool operator ==(BigMathNumber left, BigMathNumber right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(BigMathNumber left, BigMathNumber right)
    {
      return !left.Equals(right);
    }

    public static bool operator ==(BigMathNumber left, int right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(BigMathNumber left, int right)
    {
      return !left.Equals(right);
    }

    public static implicit operator BigMathNumber(int value)
    {
      var newBigNumber = new BigMathNumber();
      newBigNumber.SetValue(value);
      return newBigNumber;
    }

    public void SetValue(int value)
    {
      this.SetValue(value.ToString());
    }

    public void SetValue(BigMathNumber value)
    {
      this.SetValue(value.ToString());
    }

    public void SetValue(String value)
    {
      var newNumber = ConvertToList(value);
      internalNumber = new List<sbyte>();
      this.internalNumber.AddRange(newNumber);
    }

    private List<sbyte> ConvertToList(string value)
    {
      List<sbyte> newNumber = new List<sbyte>();
      for (int i = value.Length - 1; i >= 0; i--)
      {
        newNumber.Add(Convert.ToSByte(value.Substring(i, 1)));
      }
      return newNumber;
    }

    public override string ToString()
    {
      //remove leading zeros, but not the last
      while ((internalNumber.Last() == 0) && (internalNumber.Count > 1))
      {
        internalNumber.RemoveAt(internalNumber.Count - 1);
      }

      String retVal = String.Empty;
      foreach (sbyte val in internalNumber)
      {
        retVal = Convert.ToString(val) + retVal;
      }
      return retVal;
    }

    public bool Equals(int other)
    {
      return AreEqual(this.ToString(), other.ToString());
    }

    public bool Equals(BigMathNumber other)
    {
      return AreEqual(this.ToString(), other.ToString());
    }

    public bool Equals(Object other)
    {
      try
      {
        var otherNumber = other as BigMathNumber;
        return this.Equals(otherNumber);
      }
      catch (Exception)
      {
        return false;
      }
    }

    private bool AreEqual(string left, string right)
    {
      return (left == right);
    }

    public int GetHasCode()
    {
      return internalNumber.GetHashCode();
    }

  }
}
