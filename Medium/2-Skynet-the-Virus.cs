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
class Player
{
    static void Main(string[] args)
    {
        // Parse and set up data structures
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        int[] exits = new int[E];
        Dictionary<int,List<int>> nodes = new Dictionary<int,List<int>>();
        for (int i = 0; i < N; i++){
            nodes.Add(i,new List<int>());
        }
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            nodes[N1].Add(N2);
            nodes[N2].Add(N1);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            exits[i] = EI;
        }
        
        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            int sever1 = 0;
            int sever2 = 0;
            
            // Find a node with less than 4 links remaining - helps block virus
            for(int j = N-1; j >= 0; j--){
                if(nodes[j].Count()<4){
                    foreach(int i in nodes[j]){
                        if(!exits.Contains(i)){
                            sever1 = j;
                            sever2 = i;
                        }
                    }
                }
            }
            
            // If virus is next to an exit, remove that link    
            foreach (int i in nodes[SI]){
                if(exits.Contains(i)){
                    sever1 = SI;
                    sever2 = i;
                }
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            string sever = string.Concat(sever1, " ", sever2);
            nodes[sever1].Remove(sever2);
            nodes[sever2].Remove(sever1);
            Console.WriteLine(sever); // Example: 0 1 are the indices of the nodes you wish to sever the link between
        }
    }
}