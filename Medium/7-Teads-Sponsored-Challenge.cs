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
        // Important to use HashSets for speed, we don't care about order or want duplicates
        int n = int.Parse(Console.ReadLine()); // the number of adjacency relations
        Dictionary<int,HashSet<int>> nodes = new Dictionary<int,HashSet<int>>(); // index of node, list of adjacent nodes
        Dictionary<int, int> ec = new Dictionary<int,int>();
        HashSet<int> tn = new HashSet<int>(); // Terminal nodes (has 1 edge)
        
        // Set up data structures
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int xi = int.Parse(inputs[0]); // the ID of a person which is adjacent to yi
            int yi = int.Parse(inputs[1]); // the ID of a person which is adjacent to xi
            
            // Add nodes to dict with links going both directions
            if(nodes.ContainsKey(xi)){
                nodes[xi].Add(yi);
            } else {
                HashSet<int> tempList = new HashSet<int>();
                tempList.Add(yi);
                nodes.Add(xi,tempList);
            }
            
            if(nodes.ContainsKey(yi)){
                nodes[yi].Add(xi);
            } else {
                HashSet<int> tempList = new HashSet<int>();
                tempList.Add(xi);
                nodes.Add(yi,tempList);
            }
            
            // Count edges and remove nodes with more than 1 from terminal nodes set
            if(!ec.ContainsKey(xi)){
                ec.Add(xi,1);
                tn.Add(xi);
            } else {
                ec[xi] = ec[xi]+ 1;
                if(tn.Contains(xi)){
                    tn.Remove(xi);
                }
            }
            if(!ec.ContainsKey(yi)){
                ec.Add(yi,1);
                tn.Add(yi);
            } else {
                ec[yi]= ec[yi] + 1;
                if(tn.Contains(yi)){
                    tn.Remove(yi);
                }
            }
        }
        
        
        int distance = 0;
        bool noMoreNodes = false;
        
        // We are peeling our way to the center of the graph.
        // Increment distance, remove terminal nodes, update graph, find new terminal nodes.
        while(nodes.Count()>0 && !noMoreNodes){
            distance++;
            int tnCount = tn.Count();
            // Console.Error.WriteLine("tn count: "+ tnCount);
            // Even vs odd ending distance correction
            if(tnCount == 2 && nodes.Count()<3){ 
                noMoreNodes = true;
            } else if(tnCount == 1){
                distance--;
                noMoreNodes = true;
            } else {
                
                // Remove terminal nodes
                HashSet<int> tn2 = new HashSet<int>(); // Store new terminal nodes while updating
                foreach(int i in tn){
                    // Console.Error.WriteLine(" In: "+ i + " Count: " + nodes[i].Count());
                    int neighbor = nodes[i].ElementAt(0); // Get the only link
                    nodes.Remove(i);
                    nodes[neighbor].Remove(i);
                    ec[neighbor] = ec[neighbor]-1;
                    if(ec[neighbor] == 1){ // New terminal nodes must have only 1 link
                        tn2.Add(neighbor);
                    }
                }
                tn = new HashSet<int>(tn2);
            }
            
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(distance); // The minimal amount of steps required to completely propagate the advertisement
    }
}