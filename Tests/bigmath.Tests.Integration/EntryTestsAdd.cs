using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//int max              2147483647
//uint max             4294967295
//long max             2147483647
//ulong max            4294967295
//i64 max     9223372036854775807
//ui64 max   18446744073709551615 

namespace bigmath.Tests.Integration
{
  [TestClass]
  public class EntryTestsAdd
  {
    [TestMethod]
    public void AssertAddMethod()
    {
      string val1 = "1";
      string val2 = "1";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("2", results);
    }

    [TestMethod]
    public void AssertAddMethod100Plus100()
    {
      string val1 = "100";
      string val2 = "100";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("200", results);
    }

    [TestMethod]
    public void AssertAddMethodWithNumberGreaterThanInt()
    {
      string val1 = "2147483647"; //int max
      string val2 = "1111111111";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("3258594758", results);
    }

    [TestMethod]
    public void AssertAddMethodWithNumberGreaterThanUint()
    {
      string val1 = "4294967295";
      string val2 = "1111111111";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("5406078406", results);
    }

    [TestMethod]
    public void AssertAddMethodWithNumberGreaterThani64()
    {
      string val1 = "9223372036854775807";
      string val2 = "1111111111111111111";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("10334483147965886918", results);
    }

    [TestMethod]
    public void AssertAddMethodWithNumberGreaterThanUi64()
    {
      string val1 = "18446744073709551615";
      string val2 = "11111111111111111111";
      string results = BigMath.Add(val1, val2);
      Assert.AreEqual("29557855184820662726", results);
    }

  }
}
