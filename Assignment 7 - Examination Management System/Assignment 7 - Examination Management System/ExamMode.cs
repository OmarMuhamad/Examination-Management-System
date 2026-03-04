using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7___Examination_Management_System
{
    [Flags]
    internal enum ExamMode : Byte
    {
        Starting = 0x01, Queued = 0x02, Finished = 0x04
    } 
}
