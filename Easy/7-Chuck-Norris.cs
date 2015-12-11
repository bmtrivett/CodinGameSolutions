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
        string MESSAGE = Console.ReadLine();
        byte[] bytes = Encoding.ASCII.GetBytes(MESSAGE);
        string binary = "";
        string answer = "";
        // Convert to binary string
        foreach(byte b in bytes){
            string s = Convert.ToString(b,2);
            // ASCII must be length 7
            while(s.Length < 7){
                s = string.Concat("0",s);
            }
            binary = string.Concat(binary, s);
        }
        // Convert to unary string
        for (int i = 0; i < binary.Length-1; i++){
            // Set initial bits
            if(i == 0 && binary.ElementAt(i) == '1'){
                answer = "0 0";
            } else if(i == 0 && binary.ElementAt(i) == '0'){
                answer = "00 0";
            }
            // Set remaining bits
            if(binary.ElementAt(i) == binary.ElementAt(i+1)){
                answer = string.Concat(answer, "0");
            } else if(binary.ElementAt(i+1) == '0'){
                answer = string.Concat(answer, " 00 0");
            } else {
                answer = string.Concat(answer, " 0 0");
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(answer);
    }
}