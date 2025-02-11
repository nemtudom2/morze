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
            Dictionary<string, string> megfejtoabc = new Dictionary<string, string>();
            foreach (string line in a)
            {
                abc[line.Split('\t')[0].ToLower()] = line.Split('\t')[1];
                abc[line.Split('\t')[0].ToUpper()] = line.Split('\t')[1];
                megfejtoabc[line.Split('\t')[1].ToUpper()] = line.Split('\t')[0].ToUpper();
            }
            Console.WriteLine($"A file {abc.Count()} elemet tartalmaz");
            Console.Write($"kerek egy karaktert: ");
            var b = Console.ReadLine();
            Console.WriteLine(abc.ContainsKey(b)? abc[b] : "nincs ilyen karakter");
            
            IEnumerable<List<List<string>>> dekodolando = from y in (
                      from x in (new StreamReader("../../morze.txt").ReadToEnd().Replace("\t", "").Split('\n').ToList()) select x.Replace("       ", ":").Split(':').ToList())
                                select y.Select(x=>x.Replace("   ", ":").Split(':').ToList()).ToList();
            string dekodolt = "";
            foreach (var line in dekodolando)
            {
                foreach (var szo in line)
                {
                    foreach (var betu in szo)
                    {
                        try
                        {
                            dekodolt += megfejtoabc[betu];
                        }
                        catch
                        {
                            Console.WriteLine(betu);
                        }
                    }
                    dekodolt += " ";
                }
                dekodolt+="\n";
            }
            Console.WriteLine(dekodolt);
            Console.ReadLine();
        }
    }
}
