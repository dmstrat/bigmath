using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
//review for starting point: http://msdn.microsoft.com/en-us/library/vstudio/ms229064%28v=vs.100%29.aspx
namespace bigmath.Exceptions
{
  public class BaseBigMathException: Exception, ISerializable 
  {
    public BaseBigMathException() : base()
    {
    }

    public BaseBigMathException(string message): base(message)
    {
    }

    public BaseBigMathException(string message, Exception inner): base(message, inner)
    {
    }

    public BaseBigMathException(SerializationInfo info, StreamingContext context): base(info, context)
    {
    }
  }
}
