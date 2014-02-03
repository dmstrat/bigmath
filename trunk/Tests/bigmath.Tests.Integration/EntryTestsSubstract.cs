using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bigmath.Tests.Integration
{
  [TestClass]
  public class EntryTestsSubstract
  {
    [TestMethod]
    public void AssertSubtractMethod10Minus1()
    {
      string val1 = "10";
      string val2 = "1";
      string results = BigMath.Subtract(val1, val2);
      Assert.AreEqual("9", results);
    }

    [TestMethod]
    public void AssertSubtractMethod100Minus1()
    {
      string val1 = "100";
      string val2 = "1";
      string results = BigMath.Subtract(val1, val2);
      Assert.AreEqual("99", results);
    }

    [TestMethod]
    public void AssertSubtractMethodLargeNumberToZero()
    {
      string val1 = "123456789";
      string val2 = "123456789";
      string results = BigMath.Subtract(val1, val2);
      Assert.AreEqual("0", results);
    }

    [TestMethod]
    public void AssertSubtractMethodLargeNumberToOne()
    {
      string val1 = "987654321987654321";
      string val2 = "987654321987654320";
      string results = BigMath.Subtract(val1, val2);
      Assert.AreEqual("1", results);
    }
  }
}
