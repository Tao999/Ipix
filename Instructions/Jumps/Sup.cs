using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ipix.Instructions.Jumps
{
    class Sup : Instr
    {
        public Sup() : base()
        {
            nbArgs = 3;
        }

        public override void Proc(string args)
        {
            args = args.Trim();
            string[] tok = args.Split(" ");

            if (tok.Length != nbArgs || args.Equals(""))
            {
                Ipix.Stop("Erreur nombre de paramètre incorrect, " + nbArgs + " attendu, 0 donné");
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

            string label = tok[0];
            string var1 = Ipix.vars[tok[1]];
            string var2 = Ipix.vars[tok[2]];

            double d1, d2;

            //si les valeurs sont différentes, on sort
            if (double.TryParse(var1.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out d1) && double.TryParse(var2.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out d2))
            {
                if (d1 <= d2)
                    return;
            }
            else
            {
                Ipix.Stop("Les strings ne peuvent pas être comparés avec sup");
                return;
            }


            //sinon on saute au label
            if (!Ipix.lables.ContainsKey(label))
            {
                Ipix.Stop("Le label " + label + " n'existe pas");
                return;
            }

            Ipix.linePointer = Ipix.lables.GetValueOrDefault(label) - 1;
        }
    }
}
