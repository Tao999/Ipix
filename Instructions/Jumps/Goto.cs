using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipix.Instructions.System
{
    class Goto : Instr
    {
        public Goto() : base()
        {
            nbArgs = 1;
        }

        public override void Proc(string args)
        {
            args = args.Trim();

            if (args.Equals(""))
            {
                Ipix.Stop("Erreur nombre de paramètre incorrect, " + nbArgs + " attendu, 0 donné");
                return;
            }

            if (!Ipix.lables.ContainsKey(args))
            {
                Ipix.Stop("Le label " + args + " n'existe pas");
                return;
            }

            Ipix.linePointer = Ipix.lables.GetValueOrDefault(args) - 1;
        }
    }
}
