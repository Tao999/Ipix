using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ipix.Instructions.Operators
{
    class Div : Instr
    {
        public Div() : base()
        {
            nbArgs = 3;
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


            if (!Ipix.vars.ContainsKey(tok[0]))
            {
                Ipix.Stop("La variable \"" + tok[0] + "\"n'existe pas");
                return;
            }
            if (!Ipix.vars.ContainsKey(tok[1]))
            {
                Ipix.Stop("La variable \"" + tok[1] + "\"n'existe pas");
                return;
            }
            if (!Ipix.vars.ContainsKey(tok[2]))
            {
                Ipix.Stop("La variable \"" + tok[2] + "\"n'existe pas");
                return;
            }

            string target = tok[0];
            string var1 = Ipix.vars[tok[1]].Replace(",", "."); ;
            string var2 = Ipix.vars[tok[2]].Replace(",", "."); ;



            double f1, f2;

            if (double.TryParse(var1, NumberStyles.Any, CultureInfo.InvariantCulture, out f1) && double.TryParse(var2, NumberStyles.Any, CultureInfo.InvariantCulture, out f2))
            {
                Ipix.vars[target] = (f1 / f2).ToString().Replace(",", "."); ;
            }
            else
            {
                Ipix.Stop("Impossible de multiplier 2 strings");
                return;
            }
        }
    }
}
