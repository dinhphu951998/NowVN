using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowVN.Framework
{
    public class NowVNException : Exception
    {
        public NowVNException()
        {

        }

        public NowVNException(string message):base(message)
        {

        }

        public NowVNException(NowVNException ex) : base(ex.Message, ex)
        {

        }

    }
}
