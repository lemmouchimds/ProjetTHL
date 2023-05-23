using System.ComponentModel;

namespace ProjetTHL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var init = 0;

            var alpha = new List<char>() { 'a', 'b' };

            var finals = new List<int>() { 2, 3 };

            var trans1 = new AEFnonDet('a', 0, new List<int>() { 1, 3});
            var trans2 = new AEFnonDet('b', 0, new List<int>() { 1});
            var trans3 = new AEFnonDet('a', 1, new List<int>() { 2});
            var trans4 = new AEFnonDet('b', 1, new List<int>() { 1});
            var trans5 = new AEFnonDet('a', 2, new List<int>() { 2});
            var trans6 = new AEFnonDet('a', 3, new List<int>() { 3});


            var list = new List<AEFnonDet>();
            list.Add(trans1);
            list.Add(trans2);
            list.Add(trans3);
            list.Add(trans4);
            list.Add(trans5);
            list.Add(trans6);


            var dict = AEFnonDet.toDeterministe(alpha, list, init, finals, out var finalsOut);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }



            //var dict = new Dictionary<Tuple<char, int>, int>();
            //dict.Add(new Tuple<char, int>('a', 1), 2);
            //dict.Add(new Tuple<char, int>('a', 2), 1);
            //dict.Add(new Tuple<char, int>('c', 1), 3);
            //dict.Add(new Tuple<char, int>('c', 3), 4);
            //dict.Add(new Tuple<char, int>('c', 4), 3);
            //dict.Add(new Tuple<char, int>('a', 3), 5);
            //dict.Add(new Tuple<char, int>('b', 3), 5);
            //dict.Add(new Tuple<char, int>('a', 5), 5);
            //dict.Add(new Tuple<char, int>('b', 5), 5);
            //dict.Add(new Tuple<char, int>('c', 2), 6);
            //dict.Add(new Tuple<char, int>('c', 6), 7);
            //dict.Add(new Tuple<char, int>('c', 7), 6);
            //dict.Add(new Tuple<char, int>('a', 6), 5);
            //dict.Add(new Tuple<char, int>('b', 6), 5);

            //var dict = new Dictionary<Tuple<char, int>, List<int>>();
            //dict.Add(new Tuple<char, int>('c', 1), new List<int>(){ 2 });
            //dict.Add(new Tuple<char, int>('a', 2), new List<int>(){ 1 });
            //dict.Add(new Tuple<char, int>('c', 1), new List<int>(){ 3 });
            //dict.Add(new Tuple<char, int>('c', 3), new List<int>(){ 4 });
            //dict.Add(new Tuple<char, int>('c', 4), new List<int>(){ 3 });
            //dict.Add(new Tuple<char, int>('a', 3), new List<int>(){ 5 });
            //dict.Add(new Tuple<char, int>('b', 3), new List<int>(){ 5 });
            //dict.Add(new Tuple<char, int>('a', 5), new List<int>(){ 5 });
            //dict.Add(new Tuple<char, int>('b', 5), new List<int>(){ 5 });
            //dict.Add(new Tuple<char, int>('c', 2), new List<int>(){ 6 });
            //dict.Add(new Tuple<char, int>('c', 6), new List<int>(){ 7 });
            //dict.Add(new Tuple<char, int>('c', 7), new List<int>(){ 6 });
            //dict.Add(new Tuple<char, int>('a', 6), new List<int>(){ 5 });
            //dict.Add(new Tuple<char, int>('b', 6), new List<int>(){ 5 });

            //List<char> list = new List<char>();
            //list.Add('a');
            //list.Add('b');
            //list.Add('c');

            //var 
            //List<int> fin = new List<int>() { 3, 5, 6};
            //var automate = new AEFNonDeterministe(list, init, dict, fin);

            //Console.WriteLine(automate.CheckWord("aaccc") + " aaccc");
            //Console.WriteLine(automate.CheckWord("aacccab") + " aacccab");
            //Console.WriteLine(automate.CheckWord("aacccabc") + " aacccabc");
            //Console.WriteLine(automate.CheckWord("daaccc") + " daaccc");
            //Console.WriteLine(automate.CheckWord("aaccc1") + " aaccc1");
            //Console.WriteLine(automate.CheckWord("aaccca") + " aaccca");
            //Console.WriteLine(automate.CheckWord("aacc") + " aacc");
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine("Hello, World!");
        }

    }
}