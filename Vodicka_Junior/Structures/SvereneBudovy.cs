using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior.Structures
{
    internal class SvereneBudovy//object SvereneBudovy with constructor and its parametrs
    {
        public int Id { get; set; }
        public string Obec { get; set; }
        public string TypBudovy { get; set; }

        public SvereneBudovy(int id, string obec, string typBudovy)
        {
            Id = id;
            Obec = obec;
            TypBudovy = typBudovy;
        }
    }
}
