using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipix.Instructions.System
{
    class Mov : Instr
    {
        public Mov() : base()
        {
            nbArgs = 2;
        }

        public override void Proc(string args)
        {
            args = args.Trim();
            string[] tok = args.Split(" ", 2);

            if (tok.Length != nbArgs || args.Equals(""))
            {
                Ipix.Stop("Erreur nombre de paramètre incorrect, " + nbArgs + " attendu, " + tok.Length + " donné");
                return;
            }

            if (!Ipix.vars.ContainsKey(tok[0]))
            {
                Ipix.Stop("la variable " + tok[0] + "n'existe pas");
            }
            if (!Ipix.vars.ContainsKey(tok[1]))
            {
                Ipix.Stop("la variable " + tok[1] + "n'existe pas");
            }

            Ipix.vars[tok[0]] = Ipix.vars[tok[1]];
        }
    }
}
