namespace ProjetTHL
{
    internal class AEFDeterministe : AEF
    {
        
        public AEFDeterministe(int etatInit, Dictionary<Tuple<char, int>, int> dict, List<int> etatsFinaux)
        {
            EtatsFinaux = etatsFinaux;
            EtatInit = etatInit;

            var keys = dict.Keys;
            foreach (var item in keys)
            {
                if (!Alpha.Contains(item.Item1))
                {
                    Alpha.Add(item.Item1);
                }

                if (!Etats.Contains(item.Item2))
                {
                    Etats.Add(item.Item2);
                }
            }

            MakeTransitionComplet(dict);

        }

        void MakeTransitionComplet(Dictionary<Tuple<char, int>, int> trans)
        {
            transitions.Clear();
            Etats.Add(Etats.Count + 1);

            foreach (var etat in Etats)
            {
                foreach (var c in Alpha)
                {
                    var key = new Tuple<char, int>(c, etat);
                    if (trans.ContainsKey(key))
                    {
                        transitions.Add(key,trans[key]);
                    }
                    else
                    {
                        transitions.Add(key, Etats.Count);
                    }
                }
            }
        }

        private int sigma(char c, int etat)
        {

            return (Alpha.Contains(c)) ? transitions[new Tuple<char, int>(c, etat)] : Etats.Count;
        }

        public ResultType CheckWord(string word)
        {
            var CurrentState = EtatInit;

            foreach (var c in word)
            {
                CurrentState = sigma(c, CurrentState);
                if (CurrentState == Etats.Count)
                {
                    return ResultType.Blocked;
                }
            }

            if (EtatsFinaux.Contains(CurrentState))
            {
                return ResultType.Found;
            }

            return ResultType.NotFound;
        }

    }

    public enum ResultType
    {
        Found,
        NotFound,
        Blocked
    }
}
