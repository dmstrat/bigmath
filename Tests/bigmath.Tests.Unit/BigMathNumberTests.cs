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
    public void AssertBigMathNumberAssignNumberFromInt()
    {
      var testItem = new BigMathNumber();
      testItem = 10;
      Assert.IsTrue(testItem.Equals(10));
    }

    [TestMethod]
    public void AssertBigMathNumberAssignNumberFromAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      testItem = 10;
      var testItem2 = new BigMathNumber();
      testItem2 = 20;
      testItem = testItem2;
      Assert.AreEqual(testItem, testItem2);
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsSign()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem == 0);
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsSignToAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem == 0);
    }

    [TestMethod]
    public void AssertBigMathNumberInstantiatesWithZeroValueByEqualsMethod()
    {
      var testItem = new BigMathNumber();
      Assert.IsTrue(testItem.Equals(0));
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
      testItem = 100;
      testItem2 = 100;
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualsAnotherBigMathNumberTurnedIntoObject()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = 100;
      testItem2 = 100;
      var newObject = testItem2 as object;
      Assert.IsTrue(testItem.Equals(testItem2));
    }

    [TestMethod]
    public void BigMathNumberNotEqualAnotherBigMathNumber()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = 100;
      testItem2 = 200;
      Assert.IsTrue(testItem != testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualAnotherBigMathNumberByEqualAssignmentOperator()
    {
      var testItem = new BigMathNumber();
      var testItem2 = new BigMathNumber();
      testItem = 100;
      testItem2 = testItem;
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberEqualsAnInt()
    {
      var testItem = new BigMathNumber();
      testItem = 100;
      int testItem2 = 100;
      Assert.IsTrue(testItem == testItem2);
    }

    [TestMethod]
    public void BigMathNumberNotEqualAnInt()
    {
      var testItem = new BigMathNumber();
      testItem = 100;
      int testItem2 = 200;
      Assert.IsTrue(testItem != testItem2);
    }


  }
}
