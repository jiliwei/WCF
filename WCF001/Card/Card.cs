using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    abstract class Card
    {
        public abstract int Open();
        public abstract int Close();
        public abstract int MoveAbsolute(string pointName);
        public abstract int MoveRelative(string pointName);
        public abstract int MoveRelative(string axisName, double distance);
        public abstract int MoveContinuous(string axisName);
        public abstract int Stop(string axisName);
        public abstract int ReadDIFalse();
        public abstract int ReadDITrue();
        public abstract int ReadDOFalse();
        public abstract int ReadDOTrue();
        public abstract int SetUpDOFalse();
        public abstract int SetUpDOTrue();
        public abstract int SingleZero();
        public abstract int MultipleZero();
        public abstract int Pause();
        public abstract int Stop();
    }
}
