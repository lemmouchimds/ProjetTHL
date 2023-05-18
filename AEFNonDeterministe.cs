using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTHL
{
    public class AEFNonDeterministe : AEF
    {
        Dictionary<Tuple<char, int>, List<int>> transitions = new();
        public AEFNonDeterministe(int etatInit, Dictionary<Tuple<char, int>, List<int>> transitions)
        {
            
            this.transitions = transitions;

        }
    }
}
