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
        int N = int.Parse(Console.ReadLine());
        List<int> list = new List<int>();
                
        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            list.Add(pi);
        }
        list.Sort();
        int answer = Int32.MaxValue;
        int[] nums = new int[list.ToArray().Length];
        nums = list.ToArray();
        for(int i = 0; i < N-1; i++){
            int temp = nums[i+1]-nums[i];
            if (temp < answer){
                answer = temp;
            }
        }
            
        

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(answer);
    }
}