namespace ProjetTHL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var init = 1;
            var dict = new Dictionary<Tuple<char, int>, int>();
            dict.Add(new Tuple<char, int>('a', 1), 2);
            dict.Add(new Tuple<char, int>('a', 2), 1);
            dict.Add(new Tuple<char, int>('c', 1), 3);
            dict.Add(new Tuple<char, int>('c', 3), 4);
            dict.Add(new Tuple<char, int>('c', 4), 3);
            dict.Add(new Tuple<char, int>('a', 3), 5);
            dict.Add(new Tuple<char, int>('b', 3), 5);
            dict.Add(new Tuple<char, int>('a', 5), 5);
            dict.Add(new Tuple<char, int>('b', 5), 5);
            dict.Add(new Tuple<char, int>('c', 2), 6);
            dict.Add(new Tuple<char, int>('c', 6), 7);
            dict.Add(new Tuple<char, int>('c', 7), 6);
            dict.Add(new Tuple<char, int>('a', 6), 5);
            dict.Add(new Tuple<char, int>('b', 6), 5);


            List<int> fin = new List<int>() { 3, 5, 6};
            var automate = new AEFDeterministe(init, dict, fin);

            Console.WriteLine(automate.CheckWord("aaccc") + " aaccc");
            Console.WriteLine(automate.CheckWord("aacccab") + " aacccab");
            Console.WriteLine(automate.CheckWord("aacccabc") + " aacccabc");
            Console.WriteLine(automate.CheckWord("daaccc") + " daaccc");
            Console.WriteLine(automate.CheckWord("aaccc1") + " aaccc1");
            Console.WriteLine(automate.CheckWord("aaccca") + " aaccca");
            Console.WriteLine(automate.CheckWord("aacc") + " aacc");
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine(automate.CheckWord("aacc"));
            //Console.WriteLine("Hello, World!");
        }

    }
}