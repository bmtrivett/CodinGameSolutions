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
        // Parse input
        int N = int.Parse(Console.ReadLine());
        int[] nums = new int[N]; // Values...
        int[] ts = new int[N]; // at these times
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            ts[i] = int.Parse(inputs[0]);
            nums[i] = int.Parse(inputs[1]);
        } 

        // If there is a lot of data, average neighboring values to shrink results and smooth data
        if(nums.Count() > 200){
            Console.Error.WriteLine(N);
            List<int> shrinkNums = new List<int>(nums);
            List<int> shrinkTs = new List<int>(ts);
            while(shrinkNums.Count() > 200){
                List<int> tempList = new List<int>();
                List<int> tempList2 = new List<int>();
                int i = 0;
                while(i < shrinkNums.Count()-1){
                    tempList.Add((shrinkNums[i] + shrinkNums[i+1])/2);
                    tempList2.Add((shrinkTs[i] + shrinkTs[i+1]/2));
                    i = i + 2;
                }
                shrinkNums = tempList;
                shrinkTs = tempList2;
            }
            nums = shrinkNums.ToArray();
            ts = shrinkTs.ToArray();
            N = nums.Count();
            Console.Error.WriteLine(N);
        }
        
        // Normalize the data between 0 and 1
        double[] tN = Normalize(ts);
        double[] numsN = Normalize(nums);
        
        // Find the mode for O(1)
        double mode = tN.GroupBy(v => v).OrderByDescending(g => g.Count()).First().Key;
        
        /* Debug print graph
        foreach (double x in numsN){
            for (int i = 0; i < ((int) x) % 100; i++){
                Console.Error.Write('#');
            }
            Console.Error.WriteLine((int) x);
        }
        */
        
        // O(1)
        double[] o1 = new double[N]; // Use corresponding formula on data points to get expected values
        double[] o1N = new double[N]; // Normalize these expected values
        double[] o1E = new double[N]; // Find the error between these values and the actual values
        
        // O(logn)
        double[] logn = new double[N];
        double[] lognN = new double[N];
        double[] lognE = new double[N];
        
        // O(n)
        double[] n = new double[N];
        double[] nN = new double[N];
        double[] nE = new double[N];
        
        // O(n*logn)
        double[] nlogn = new double[N];
        double[] nlognN = new double[N];
        double[] nlognE = new double[N];
        
        // O(n^2)
        double[] n2 = new double[N];
        double[] n2N = new double[N];
        double[] n2E = new double[N];
        
        // O(n^2*logn)
        double[] n2logn = new double[N];
        double[] n2lognN = new double[N];
        double[] n2lognE = new double[N];
        
        // O(n^3)
        double[] n3 = new double[N];
        double[] n3N = new double[N];
        double[] n3E = new double[N];
        
        // O(2^n)
        double[] o2n = new double[N];
        double[] o2nN = new double[N];
        double[] o2nE = new double[N];
        
        // Populate formulas with n values
        for(int i = 0; i < N; i++){
            o1[i] = mode; // O(1) should be near the mode of the values every time
            logn[i] = Math.Log(ts[i]);
            n[i] = ts[i];
            nlogn[i] = ts[i]*Math.Log(ts[i]);
            n2[i] = Math.Pow(ts[i],2);
            n2logn[i] = Math.Pow(ts[i],2)*Math.Log(ts[i]);
            n3[i] = Math.Pow(ts[i],3);
            o2n[i] = Math.Pow(2,ts[i]);
            //Console.Error.WriteLine("tN[i] = " +tN[i] + " Log(tN[i]) = "+ Math.Log(tN[i]) + " Pow(tN[i],2) = " + Math.Pow(tN[i],2));
        }
        
        // Normalize
        o1N = o1;
        lognN = Normalize(logn);
        nN = Normalize(n);
        nlognN = Normalize(nlogn);
        n2N = Normalize(n2);
        n2lognN = Normalize(n2logn);
        n3N = Normalize(n3);
        o2nN = Normalize(o2n);
        
        // Find the errors between normalized values and normalized equations
        o1E = FindError(o1N, numsN);
        lognE = FindError(lognN, numsN);
        nE = FindError(nN, numsN);
        nlognE = FindError(nlognN, numsN);
        n2E = FindError(n2N, numsN);
        n2lognE = FindError(n2lognN, numsN);
        n3E = FindError(n3N, numsN);
        o2nE = FindError(o2nN, numsN);
        
        // Add up all the error values for each formula's array
        double[] sumE = new double[8];
        for (int i = 0; i < N; i++){ 
            sumE[0] = sumE[0] + o1E[i];
            sumE[1] = sumE[1] + lognE[i];
            sumE[2] = sumE[2] + nE[i];
            sumE[3] = sumE[3] + nlognE[i];
            sumE[4] = sumE[4] + n2E[i];
            sumE[5] = sumE[5] + n2lognE[i];
            sumE[6] = sumE[6] + n3E[i];
            sumE[7] = sumE[7] + o2nE[i];
        }
        
        // Get the lowest error
        double lowestError = Int32.MaxValue;
        for (int i = 0; i < 8; i++){
            Console.Error.WriteLine(sumE[i]);
            if(sumE[i] < lowestError){
                lowestError = sumE[i];
            }
        }
        List<double> sumE2 = new List<double>(sumE);
        int index = sumE2.IndexOf(lowestError);
        
        // Print the complexity formula with lowest error
        string answer = "";
        switch(index){
            case 0:
                answer = "O(1)";
                break;
            case 1:
                answer = "O(log n)";
                break;
            case 2:
                answer = "O(n)";
                break;
            case 3:
                answer = "O(n log n)";
                break;
            case 4:
                answer = "O(n^2)";
                break;
            case 5:
                answer = "O(n^2 log n)";
                break;
            case 6:
                answer = "O(n^3)";
                break;
            case 7:
                answer = "O(2^n)";
                break;
        }
        Console.WriteLine(answer);
    }
    
    // Find the errors between 2 corresponding size N arrays of values
    private static double[] FindError(double[] a1, double[] a2){
        int N = a1.Length;
        double[] answer = new double[N];
        for (int i = 1; i < N-1; i++){
            answer[i] = Math.Abs(a1[i]-a2[i]);
        }
        return answer;
    }
    
    // Normalize: 0 is lowest value in array, 1 is highest.
    // Values between are represented as a percentage of the highest value
    private static double[] Normalize(double[] array){
        int N = array.Length;
        double[] answer = new double[N];
        double max = array.Max();
        double min = array.Min();
        for (int i = 0; i < N; i++){
            answer[i] =  (array[i]-min)/(max-min);
        }
        return answer;
    }
    // Overload normalize method
    private static double[] Normalize(int[] a1){
        int N = a1.Length;
        double[] array = new double[N];
        for (int i = 0; i < N; i++){
            array[i] = (double)a1[i];
        }
        return Normalize(array);
    }
    
}