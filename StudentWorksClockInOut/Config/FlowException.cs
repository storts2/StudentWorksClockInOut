using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Config;

internal class FlowException : Exception
{
    public FlowException(string message) : base(message) { 

    }
}
