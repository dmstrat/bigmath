using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bigmath.Tests.Integration
{
  [TestClass]
  public class EntryTestsExponential
  {
    [TestMethod]
    public void AssertExponential()
    {
      string val1 = "10";
      string val2 = "2";
      string results = BigMath.Exponential(val1, val2);
      Assert.AreEqual("100", results);
    }
    [TestMethod]
    public void AssertExponentialOf11To2()
    {
      string val1 = "11";
      string val2 = "2";
      string results = BigMath.Exponential(val1, val2);
      Assert.AreEqual("121", results);
    }
    [TestMethod]
    public void AssertExponentialOf15To5()
    {
      string val1 = "15";
      string val2 = "5";
      string results = BigMath.Exponential(val1, val2);
      Assert.AreEqual("759375", results);
    }
    [TestMethod]
    public void AssertExponentialOf20To20()
    {
      string val1 = "20";
      string val2 = "20";
      string results = BigMath.Exponential(val1, val2);
      Assert.AreEqual("104857600000000000000000000", results);
    }
  }
}
