using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bigmath.Tests.Integration
{
  [TestClass]
  public class EntryTestsFactorial
  {
    [TestMethod]
    public void AssertFactorial()
    {
      string val1 = "2";
      string results = BigMath.Factorial(val1);
      Assert.AreEqual("2", results);
    }
    [TestMethod]
    public void AssertFactorialOf5()
    {
      string val1 = "5";
      string results = BigMath.Factorial(val1);
      Assert.AreEqual("120", results);
    }
    [TestMethod]
    public void AssertFactorialOf10()
    {
      string val1 = "10";
      string results = BigMath.Factorial(val1);
      Assert.AreEqual("3628800", results);
    }
    [TestMethod]
    public void AssertFactorialOf15()
    {
      string val1 = "15";
      string results = BigMath.Factorial(val1);
      Assert.AreEqual("1307674368000", results);
    }
  }
}
