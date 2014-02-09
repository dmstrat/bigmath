using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bigmath;

namespace bigmath.Tests.Unit
{
  [TestClass]
  public class BigMathNumberTests
  {
    [TestMethod]
    public void AssertBigMathNumberExists()
    {
      var testItem = new BigMathNumber();
      Assert.IsInstanceOfType(testItem, typeof(BigMathNumber));
    }

    [TestMethod]
    public void AssertBigMathNumberAssignNumberFromString()
    {
      var testItem = new BigMathNumber();
      testItem = "10";
      Assert.IsTrue(testItem.Equals("10"));
    }

    [TestMethod]
    public void AssertBigMathNumberAssignNumberFromAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      testItem = "10";
      var testItem2 = new BigMathNumber();
      testItem2 = "20";
      testItem = testItem2;
      Assert.AreEqual(testItem, testItem2);
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsSign()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem == "0");
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsSignToAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem == "0");
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsMethod()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem.Equals("0"));
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsMethodToAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      Assert.IsTrue(testItem.Equals(testItem2));
    }

    [TestMethod]
    public void BigMathNumberEqualsAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = "100";
      testItem2 = "100";
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualsAnotherBigMathNumberTurnedIntoObject()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = "100";
      testItem2 = "100";
      var newObject = testItem2 as object;
      Assert.IsTrue(testItem.Equals(testItem2));
    }

    [TestMethod]
    public void BigMathNumberNotEqualAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = "100";
      testItem2 = "200";
      Assert.IsTrue(testItem != testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualAnotherBigMathNumberByEqualAssignmentOperator()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = "100";
      testItem2 = testItem;
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualsAString()
    {
      var testItem = new BigMathNumber();
      testItem = "100";
      var testItem2 = "100";
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberNotEqualAString()
    {
      var testItem = new BigMathNumber();
      testItem = "100";
      string testItem2 = "200";
      Assert.IsTrue(testItem != testItem2);
    }

    [TestMethod]
    public void BigMathIsNumericTestNullFails()
    {
      string testNumber = null;
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestNegative123456()
    {
      var testNumber = "-123456";
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTest123456()
    {
      var testNumber = "123456";
      Assert.IsTrue(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTest123456789987654321123456789987654321()
    {
      var testNumber = "123456789987654321123456789987654321";
      Assert.IsTrue(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestInt64MaxValueToStringPasses()
    {
      var testNumber = Int64.MaxValue.ToString();
      Assert.IsTrue(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestInt64MinValueToStringFails()
    {
      var testNumber = Int64.MinValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestLongMaxValueToStringPasses()
    {
      var testNumber = long.MaxValue.ToString();
      Assert.IsTrue(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestLongMinValueToStringFails()
    {
      var testNumber = long.MinValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestDoubleMaxValueToStringFails()
    {
      var testNumber = double.MaxValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestDoubleMinValueToStringFails()
    {
      var testNumber = double.MinValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestFloatMaxValueToStringFails()
    {
      var testNumber = float.MaxValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    public void BigMathIsNumericTestFloatMinValueToStringFails()
    {
      var testNumber = float.MinValue.ToString();
      Assert.IsFalse(BigMathHelper.IsNumeric(testNumber));
    }

    [TestMethod]
    [ExpectedException(typeof(System.ArgumentOutOfRangeException),"BigMathDoesntAllowNegativeNumbersYet: Invalid Number was provided, but somehow was allowed")]
    public void BigMathDoesntAllowNegativeNumbersYet()
    {
      var testNumber = "-123456";
      testBigNumber.SetValue(testNumber);
    }

  }
}
