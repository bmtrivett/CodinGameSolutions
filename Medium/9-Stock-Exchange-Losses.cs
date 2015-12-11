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
        int n = int.Parse(Console.ReadLine());
        string vs = Console.ReadLine();
        string[] nums = vs.Split(' ');
        int high = 0;
        int low = 0;
        int tempHigh = Int32.MinValue;
        int tempLow = Int32.MaxValue;
        
        // Find the largest loss
        foreach(string s in nums){
            int x = Int32.Parse(s);
            
            /*
            // Displays graph
            for(int i = 0; i < x; i++){ 
                Console.Error.Write("|");
            }
            Console.Error.Write("x");
            */
            
            if(x <= tempLow){
                //Console.Error.Write(" - new tempLow("+x+")");
                tempLow = x;
                
            }
            if(x > tempHigh){
                //Console.Error.Write(" - new tempHigh("+x+")");
                tempHigh = x;
                tempLow = Int32.MaxValue;
            }
            
            if(tempLow - tempHigh <= low - high){
                //Console.Error.Write(" - new dist("+(tempHigh-tempLow)+")");
                low = tempLow;
                high = tempHigh;
            }
            //Console.Error.WriteLine(); // For displaying graph
        }
        
        //Console.Error.WriteLine();
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine((high-low)*-1);
    }
}