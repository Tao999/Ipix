using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipix.Instructions.System
{
    class End : Instr
    {
        public End() : base()
        {
            nbArgs = 0;
        }

        public override void Proc(string args)
        {
            Ipix.Stop("Arrêt du programme demmandé");
        }
    }
}
