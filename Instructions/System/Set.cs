using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipix.Instructions.System
{
    class Set : Instr
    {
        public Set() : base()
        {
            nbArgs = 2;
        }

        public override void Proc(string args)
        {
            args = args.Trim();
            string[] tok = args.Split(" ", 2);

            if(tok.Length != nbArgs || args.Equals(""))
            {
                Ipix.Stop("Erreur nombre de paramètre incorrect, " + nbArgs + " attendu, " + tok.Length + " donné");
                return;
            }

            if (Ipix.vars.ContainsKey(tok[0]))
                Ipix.vars[tok[0]] = tok[1];
            else
                Ipix.vars.Add(tok[0], tok[1]);
        }

    }
}
