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
        double LON = Convert.ToDouble(Console.ReadLine().Replace(',', '.'));
        double LAT = Convert.ToDouble(Console.ReadLine().Replace(',', '.'));
        int N = int.Parse(Console.ReadLine());
        string[,] loc = new string[N,6];
            
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            string[] temp = new string[6];
            temp = DEFIB.Split(';');
            for(int j = 0; j < temp.Length; j++){
                loc[i,j] = temp[j];
            }
            loc[i,4] = loc[i,4].Replace(',', '.');
            loc[i,5] = loc[i,5].Replace(',', '.');
        }
        
        double shortestDist = Double.MaxValue;
        string name = "";
        for (int i = 0; i < N;i++){
            string[] x = new string[6];
            for(int j = 0; j<6;j++){
                x[j] = loc[i,j];
            }
            double temp = DistBetween(LAT,LON,Convert.ToDouble(x[5]),Convert.ToDouble(x[4]));
            if(temp<shortestDist){
                shortestDist = temp;
                name = x[1];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(name);
    }
    
    static double DistBetween(double latA,double lonA,double latB,double lonB){
        return Math.Sqrt(Math.Pow(((lonB-lonA)*Math.Cos((latA+latB)/2)),2) + Math.Pow((latB-latA),2))*6371;
    }
}