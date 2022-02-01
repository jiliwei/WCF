using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    class CardGTS : Card
    {

        public override int Open()
        {
            return 0;
        }
        public override int Close()
        {
            return 0;
        }

        public override int Pause()
        {
            return 0;
        }

        public override int Stop()
        {
            return 0;
        }

        public override int MoveAbsolute(string pointName)
        {
            return 0;
        }

        public override int MoveRelative(string pointName)
        {
            return 0;
        }
        public override int MoveRelative(string axisName, double distance)
        {
            return 0;
        }

        public override int MoveContinuous(string axisName)
        {
            return 0;
        }
        public override int Stop(string axisName)
        {
            return 0;
        }

        public override int ReadDIFalse()
        {
            return 0;
        }

        public override int ReadDITrue()
        {
            return 0;
        }

        public override int ReadDOFalse()
        {
            return 0;
        }

        public override int ReadDOTrue()
        {
            return 0;
        }

        public override int SetUpDOFalse()
        {
            return 0;
        }

        public override int SetUpDOTrue()
        {
            return 0;
        }

        public override int SingleZero()
        {
            return 0;
        }

        public override int MultipleZero()
        {
            return 0;
        }
    }
}
