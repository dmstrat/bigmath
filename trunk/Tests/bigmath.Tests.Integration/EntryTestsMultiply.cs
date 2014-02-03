using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bigmath.Tests.Integration
{
  [TestClass]
  public class EntryTestsMultiply
  {
    [TestMethod]
    public void AssertMultiplyMethod2Times2()
    {
      string val1 = "2";
      string val2 = "2";
      string results = BigMath.Multiply(val1, val2);
      Assert.AreEqual("4", results);
    }

    [TestMethod]
    public void AssertMultiplyMethod200Times200()
    {
      string val1 = "200";
      string val2 = "200";
      string results = BigMath.Multiply(val1, val2);
      Assert.AreEqual("40000", results);
    }

    [TestMethod]
    public void AssertMultiplyMethod123456789Times123456789()
    {
      string val1 = "123456789";
      string val2 = "123456789";
      string results = BigMath.Multiply(val1, val2);
      Assert.AreEqual("15241578750190521", results);
    }

  }
}
