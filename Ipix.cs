using Ipix.Instructions.Operators;
using Ipix.Instructions.System;
using Ipix.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ipix
{
    enum STATUS {
        RUNNING,
        STOP,
    };
    class Ipix
    {
        Dictionary<string, Instr> instructions;
        public static Dictionary<string, string> vars;
        public static Dictionary<string, int> lables;
        public static int linePointer;

        static public STATUS status;

        public Ipix()
        {
            status = STATUS.RUNNING;
            lables = new Dictionary<string, int>();
            vars = new Dictionary<string, string>();
            instructions = new Dictionary<string, Instr>();
            //Déclaration des instructions
            instructions.Add("set", new Set());
            instructions.Add("print", new Print());
            instructions.Add("end", new End());
            instructions.Add("goto", new Goto());
            instructions.Add("add", new Add());
            instructions.Add("sub", new Sub());
            instructions.Add("mul", new Sub());
            instructions.Add("div", new Div());


        }

        public void Run()
        {
            string[] program = LoadFile(Console.ReadLine());
            if(program == null)
            {
                Stop("Le fichier proposé n'existe pas, ou n'est pas valide");
            }
            else
            {
                // le programme s'arrête si on a fini le fichier, ou que le statut de l'appli est sur "stop"
                for (linePointer = 0; (linePointer < program.Length) && (status == STATUS.RUNNING); linePointer++)
                {
                    string line = program[linePointer].Trim();
                    ProcInstr(line);
                }
            }
        }

        private void ProcInstr(string instr)
        {
            //découpement de la ligne
            string args = "";
            string[] tok = instr.Split(" ", 2);
            string instruction = tok[0];
            if(tok.Length>1)
                args = tok[1];

            if (!instructions.ContainsKey(instruction))
            {
                Stop("L'instruction \"" + instruction + "\" n'a pas été trouvée");
            }
            else
            {
                instructions.GetValueOrDefault(instruction).Proc(args);
            }
        }

        //méthode à appeler lors d'une érreur
        public static void Stop(string msg)
        {
            Console.WriteLine("===========");
            Console.WriteLine(msg);
            Console.WriteLine("Ligne {0}", linePointer + 1);
            status = STATUS.STOP;
        }

        private string[] LoadFile(string pathFile)
        {
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("le fichier n'existe pas");
                return null;
            }

            //on charge le fichier
            string[] lines = File.ReadAllLines(pathFile);
            List<string> finalValue = new List<string>();
            foreach (string line in lines)
            {
                string l = line.Trim();
                if (!(l.StartsWith("//") || l.Equals("")))
                    if (l.StartsWith(":"))
                    {
                        string label = l.Split(":", 2)[1].Trim();
                        if (lables.ContainsKey(label))
                        {
                            Console.WriteLine("Le label {0} existe déjà", label);
                            return null;
                        }
                        lables.Add(label, finalValue.Count);
                    }
                    else
                        finalValue.Add(l);
            }

            return finalValue.ToArray();
        }
    }
}
