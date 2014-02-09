using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bigmath
{
  internal struct BigMathNumber :  IEquatable<BigMathNumber>
  {
    private List<sbyte> _internalNumber { get; set; }

    public List<sbyte> internalNumber 
    {
      get
      {
        if (_internalNumber == null)
        {
          _internalNumber = new List<sbyte>();
        }
        return _internalNumber;
      }
      set
      {
        _internalNumber = value;
      }
    }

    private bool isInitialized { get; set; }

#region Operators

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
      answer = BigMathHelper.Multiply(left, right);
      return answer;
    }

    public static BigMathNumber operator /(BigMathNumber left, BigMathNumber right)
    {
      BigMathNumber answer = new BigMathNumber();
      //answer = BigMathHelper.Divide(left, right);
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

    public static bool operator ==(BigMathNumber left, string right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(BigMathNumber left, string right)
    {
      return !left.Equals(right);
    }

    public static implicit operator BigMathNumber(string value)
    {
      var newBigNumber = new BigMathNumber();
      newBigNumber.SetValue(value);
      return newBigNumber;
    }

    //public static implicit operator BigMathNumber(int value)
    //{
    //  var newBigNumber = new BigMathNumber();
    //  newBigNumber.SetValue(value);
    //  return newBigNumber;
    //}

#endregion

    //public void SetValue(int value)
    //{
    //  this.SetValue(value.ToString());
    //}

    public void SetValue(String value)
    {

      var newNumber = ConvertToList(value);
      internalNumber = new List<sbyte>();
      this.internalNumber.AddRange(newNumber);
    }

    private List<sbyte> ConvertToList(string value)
    {
      if (!BigMathHelper.IsNumeric(value))
      {
        throw new ArgumentOutOfRangeException("Value provided is not a valid number.");
      }
      List<sbyte> newNumber = new List<sbyte>();
      for (int i = value.Length - 1; i >= 0; i--)
      {
        newNumber.Add(Convert.ToSByte(value.Substring(i, 1)));
      }
      return newNumber;
    }

    public override string ToString()
    {
      if (internalNumber == null)
      {
        return "0"; 
      }

      if (internalNumber.Count == 0)
      {
        return "0";
      }
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

    public bool Equals(string other)
    {
      return AreEqual(this.ToString(), other);
    }

    public bool Equals(BigMathNumber other)
    {
      return AreEqual(this.ToString(), other.ToString());
    }

    public bool Equals(Object other)
    {
      try
      {
        var otherNumber = (BigMathNumber)other;// as BigMathNumber;
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
