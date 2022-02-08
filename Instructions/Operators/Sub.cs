using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ipix.Instructions.Operators
{
    class Sub : Instr
    {
        public Sub() : base()
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
            if (!Ipix.vars.ContainsKey(tok[1]) && !tok[1].StartsWith("$"))
            {
                Ipix.Stop("La variable \"" + tok[1] + "\"n'existe pas");
                return;
            }
            if (!Ipix.vars.ContainsKey(tok[2]) && !tok[2].StartsWith("$"))
            {
                Ipix.Stop("La variable \"" + tok[2] + "\"n'existe pas");
                return;
            }

            string var1, var2;

            string target = tok[0];
            if (tok[1].StartsWith("$"))
                var1 = tok[1].Replace("$", "");
            else
                var1 = Ipix.vars[tok[1]].Replace(",", ".");

            if (tok[2].StartsWith("$"))
                var2 = tok[2].Replace("$", "");
            else
                var2 = Ipix.vars[tok[2]].Replace(",", ".");



            double d1, d2;

            if (double.TryParse(var1, NumberStyles.Any, CultureInfo.InvariantCulture, out d1) && double.TryParse(var2, NumberStyles.Any, CultureInfo.InvariantCulture, out d2))
            {
                Ipix.vars[target] = (d1 - d2).ToString().Replace(",", "."); ;
            }
            else
            {
                Ipix.Stop("Impossible de soustraire 2 strings");
                return;
            }
        }
    }
}
