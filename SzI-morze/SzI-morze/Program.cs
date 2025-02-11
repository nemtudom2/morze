using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzI_morze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new StreamReader("../../morzeabc.txt").ReadToEnd().Replace("\r\n", "\n").Split('\n').ToList();
            a.RemoveAt(0);
            Dictionary<string, string> abc = new Dictionary<string, string>();
            foreach (string line in a)
            {
                abc[line.Split('\t')[0].ToLower()] = line.Split('\t')[1];
                abc[line.Split('\t')[0].ToUpper()] = line.Split('\t')[1];
            }
            Console.WriteLine($"A file {abc.Count()} elemet tartalmaz");
            Console.Write($"kerek egy karaktert: ");
            var b = Console.ReadLine();
            Console.WriteLine(abc.ContainsKey(b)? abc[b] : "nincs ilyen karakter");
            Console.ReadLine();
        }
    }
}
