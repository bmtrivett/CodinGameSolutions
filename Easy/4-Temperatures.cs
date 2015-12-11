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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] array = Console.ReadLine().Trim().Split(' '); // the n temperatures expressed as integers ranging from -273 to 5526
       
        int result = Int32.MaxValue;
        if (n == 0){
            result = 0;
        } else {
            foreach (string x in array){
                int num = int.Parse(x);
                //Console.Error.WriteLine(num);
                if(Math.Abs(num) < Math.Abs(result)){
                    result = num;
                } else if((Math.Abs(num) == Math.Abs(result))&&(num>result)){
                    result = num;
                }
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        
        Console.WriteLine(result);
    }
}