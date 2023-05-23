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
        public AEFNonDeterministe(List<char> alpha, int etatInit, Dictionary<Tuple<char, int>, List<int>> transitions, List<int> finals)
        {
            this.Alpha = alpha;
            this.transitions = transitions;
            this.EtatInit = etatInit;
            this.EtatsFinaux = finals;

        }

        public Dictionary<Tuple<char, int>, int> toDeterministe()
        {
            List<List<int>> result = new();

            var query = from item in transitions
                        where item.Key.Item2 == EtatInit
                        select item.Key;

            result.Add(new List<int>(EtatInit));

            List<int> temp = new();
            foreach (var item in query)
            {

                temp.Add(item.Item2);
            }

            result.Add(temp);

            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < Alpha.Count; j++)
                {
                    var query2 = from item in transitions
                                 where item.Key.Item1 == Alpha[j] && result[i].Contains(item.Key.Item2)
                                 select item.Key;
                    List<int> temp2 = new();
                    foreach (var item in query2)
                    {
                        temp2.Add(item.Item2);
                    }
                    if (temp2.Count > 0)
                    {
                        result.Add(temp2);
                    }
                }
            }

            Dictionary<Tuple<char, int>, int> result2 = new();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < Alpha.Count; j++)
                {
                    result2.Add(new Tuple<char, int>(Alpha[j], i), result[i][j]);
                }
            }

            return result2;


        }

        //private static bool equals(List<int> a, List<int> b)
        //{
        //    foreach (var item in a)
        //    {

        //    }

        //    return true;

        //}
    }


    public record AEFnonDet(char c, int fromState, List<int> toStates)
    {
        public static Dictionary<Tuple<char, int>, int> toDeterministe(List<char> alpha, List<AEFnonDet> l, int init, List<int> finals, out List<int> finalsOut)
        {
            var result = new Dictionary<Tuple<char, int>, int>();

            var temp = l.Where(a => a.fromState == init);

            Dictionary<List<int>, int> dictListEtat = new();

            int i = 0;
            var initList = new List<int>() { init };
            dictListEtat.Add(initList, i);
            i++;

            Queue<List<int>> queue = new();
            queue.Enqueue(initList);
            //get the first line
            foreach (var item in temp)
            {
                if (!dictListEtat.ContainsKey(item.toStates))
                {
                    var toInsert = item.toStates;
                    dictListEtat.Add(toInsert, i);
                    i++;
                    queue.Enqueue(toInsert);
                }
            }


            //get all matrice
            while (queue.TryDequeue(out var element))
            {
                //get the element to test
                dictListEtat.TryGetValue(element, out var x);

                //add to queue and to dictListEtat if needed
                foreach (var character in alpha)
                {
                    //var listToInsert = l.Where(q => q.c == character && x.Key.Contains(q.fromState)).ToList();
                    //var example = l.Where(q => q.c == character && element.Contains(q.fromState)).OrderBy(q => q.fromState).Select(q => q.fromState).ToList();
                    var example = l.Where(q => q.c == character && element.Contains(q.fromState)).OrderBy(q => q.fromState).Select(q => q.toStates).FirstOrDefault(); 
                    
                    if (example != null && example.Count != 0)
                    {
                        if (!dictListEtat.TryGetValue(example, out var test))
                        {
                            queue.Enqueue(example);
                            dictListEtat.Add(example, i); i++;
                        }

                        //add to dict result
                        //var arg1 = dictListEtat[element];
                        //dictListEtat.TryGetValue(example, out var arg2);
                        result.Add(new Tuple<char, int>(character, x), test);

                    }
                    else
                    {
                        //dictListEtat.TryGetValue(element, )
                        result.Add(new Tuple<char, int>(character, x), -1);
                    }
                }
            }

            finalsOut = new List<int>();

            foreach (var item in dictListEtat)
            {
                var key = item.Key;

                foreach (var item1 in key)
                {
                    if (finals.Contains(item1) && !finalsOut.Contains(dictListEtat[key]))
                    {
                        finalsOut.Add(dictListEtat[key]);
                        break;
                    }
                }
            }



            return result;

        }
    }
}
