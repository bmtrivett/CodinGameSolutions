using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        Dictionary<string, string> dict = new Dictionary<string, string>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0]; // file extension
            string MT = inputs[1]; // MIME type.
            dict.Add(EXT.ToLower(),MT);
        }
        for (int i = 0; i < Q; i++)
        {
            string answer = "UNKNOWN";
            string FNAME = Console.ReadLine(); // One file name per line.
            int index = FNAME.LastIndexOf(".");
            if (index == -1){
            } else {
                string ext = FNAME.Substring(index+1,FNAME.Length - index - 1).ToLower();
                if(dict.ContainsKey(ext)){
                    answer = dict[ext];
                }
            }
            Console.WriteLine(answer);
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
    }
}