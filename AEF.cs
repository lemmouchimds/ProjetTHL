using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTHL
{
    public abstract class AEF
    {
        protected List<char> Alpha = new();
        protected List<int> Etats = new();
        
        protected int EtatInit { get; set; }
        protected List<int> EtatsFinaux = new();
        protected Dictionary<Tuple<char, int>, int> transitions = new();
    }

    public record State(int etat, bool isFinal, bool IsNewAdded);
}
