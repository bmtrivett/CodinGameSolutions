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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        string[,] ascii = new string[H,27];
        string[,] answer = new string[H,T.Length];
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            for (int j = 0; j < (ROW.Length+1)/L;j++){
                ascii[i,j] = ROW.Substring(L*j,L);
            }
        }
        string lookup = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        for (int i = 0; i < T.Length; i++){
            char x = T.ToUpper().ElementAt(i);
            int index = lookup.IndexOf(x);
            if(index == -1){
                for (int j = 0; j < H; j++){
                    answer[j,i] = ascii[j,26];
                }
            } else {
                for (int j = 0; j < H; j++){
                    answer[j,i] = ascii[j,index];
                }
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        for (int i = 0; i < H; i++){
            for (int j = 0; j < T.Length; j++){
                Console.Write(answer[i,j]);
            }
            Console.WriteLine();
        }    
            
    }
}