using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//test of commit 
namespace bigmath
{
  public interface IBigMath
  {
    String Add(String Left, String Right);
    String Subtract(String Left, String Right);
    String Multiply(String Left, String Right);
    String Divide(String Dividend, String Devisor);
    String Factoral(String Number);
    String Exponential(String BaseNumber, String Exponent);
  }

}
