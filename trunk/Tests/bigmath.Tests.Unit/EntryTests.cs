using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bigmath.Tests.Unit
{
  [TestClass]
  public class EntryTests
  {
    [TestMethod]
    public void AssertStaticAddMethod()
    {
      var testLeft = "1";
      var testRight = "1";
      var testResult = BigMath.Add(testLeft, testRight);
    }

    [TestMethod]
    public void AssertStaticSubtractMethod()
    {
      var testLeft = "1";
      var testRight = "1";
      var testResult = BigMath.Subtract(testLeft, testRight);
    }

    [TestMethod]
    public void AssertStaticMultiplyMethod()
    {
      var testLeft = "1";
      var testRight = "1";
      var testResult = BigMath.Multiply(testLeft, testRight);
    }

    //[TestMethod]
    //public void AssertStaticDivideMethod()
    //{
    //  var testTop = "1";
    //  var testBottom = "1";
    //  var testResult = BigMath.Add(testTop, testBottom);
    //}

    [TestMethod]
    public void AssertStaticFactoralMethod()
    {
      var testNumber = "1";
      var testResult = BigMath.Factorial(testNumber);
    }

    [TestMethod]
    public void AssertStaticExponentialMethod()
    {
      var testBaseNumber = "1";
      var testExponent = "1";
      var testResult = BigMath.Exponential(testBaseNumber, testExponent);
    }

  }
}
