using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipix.Instructions.System
{
    class Print : Instr
    {
        public Print() : base()
        {
            nbArgs = 1;
        }

        public override void Proc(string args)
        {
            args = args.Trim();
            string[] tok = args.Split(" ");

            if (tok.Length != nbArgs || args.Equals(""))
            {
                Ipix.Stop("Erreur nombre de paramètre incorrect, " + nbArgs + " attendu, " + tok.Length + " donné");
                return;
            }

            string varName = tok[0].Trim();

            if (!Ipix.vars.ContainsKey(varName))
            {
                Ipix.Stop("Variable, " + varName + " n'existe pas");
                return;
            }

            string value = Ipix.vars.GetValueOrDefault(varName);

            Console.WriteLine(value);
        }
    }
}
