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
    
    static void Main(string[] args){
       
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        int[] exits = new int[E];
        Dictionary<int,HashSet<int>> nodes = new Dictionary<int,HashSet<int>>();
        
        //Initialize nodes, links, and exits
        for (int i = 0; i < N; i++){
            nodes.Add(i,new HashSet<int>());
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
            string sever = "";
            int sever1 = -1;
            int sever2 = -1;
            bool doneSearching = false;
            
            // Sever adjacent exit links first
            foreach(int i in nodes[SI]){
                if(exits.Contains(i)){
                    sever1 = SI;
                    sever2 = i;
                    doneSearching = true;
                }
            }
            
            // Find closest node with more than one exit link if not next to an exit
            if(!doneSearching){
                int min = Int32.MaxValue;
                for(int i = 0; i < nodes.Count(); i++){ // Make sure you look at all the nodes
                    int distance = 0;
                    int count = 0;
                    if(!exits.Contains(i)){ // Don't check gateways
                        foreach(int j in nodes[i]){ // Count the exit links for this node
                            if(exits.Contains(j)){
                                count++;
                            }
                        }
                        if(count > 1){ // Only get the distance to this node if it has more than 1 exit link
                            distance =  BreadthFirstModified(SI,i,nodes,exits); // Get the shortest distance from SI to i
                            //Console.Error.WriteLine("Start: "+ SI + " Finish: " + i + " Distance: " + distance + " Count: " + count);
                        }
                    }
                    if(distance < min && count > 1){ // If we got a shorter distance for this node
                        min = distance; // Set a new minimum and
                        sever1 = i;
                        foreach(int j in nodes[i]){ // pick one of the exit links
                            if(exits.Contains(j)){
                                sever2 = j;
                                break;
                            }
                        }
                    }
                }
                
                // If all of the nodes have only 0 or 1 exit links pick any of them
                if(sever1 == -1){ 
                    foreach(int i in exits){
                        foreach(int j in nodes[i]){
                            sever1 = i;
                            sever2 = j;
                            break;
                        }
                        if(sever1 != -1){
                            break;
                        }
                    }
                }
                
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            //Console.Error.WriteLine(sever1 + ":" + sever2);
            sever = string.Concat(sever1, " ", sever2);
            nodes[sever1].Remove(sever2);
            nodes[sever2].Remove(sever1);
            Console.WriteLine(sever); // Example: 0 1 are the indices of the nodes you wish to sever the link between
        }
    }
    

    // Get the shortest distance between two nodes on a graph
    // Modification: only increment distance if the node we travel across has 0 exit links.
    // Do this because when we are at a node with an exit link, that is the only move we will make
    public static int BreadthFirstModified(int start, int finish, Dictionary<int, HashSet<int>> nodes, int[] exits){
        int distance = 0;
        int currentLocation = start;
        HashSet<int> visited = new HashSet<int>();
        Queue<int[]> q = new Queue<int[]>(); // Queue of node locations and distances
        bool foundExit = false;
        int[] startLoader = new int[2]; // position 0 is node location, position 1 is the distance to that node
        startLoader[0] = start;
        startLoader[1] = distance;
        q.Enqueue(startLoader);
        
        while (!foundExit && q.Count > 0){
            int[] loader = new int[2];
            loader = q.Dequeue();
            currentLocation = loader[0];
            distance = loader[1];
            visited.Add(currentLocation);
            //Console.Error.WriteLine("In: "+ currentLocation);
            bool nearExit = false;
            foreach(int i in nodes[currentLocation]){ // Look for exit links at this node
                if(exits.Contains(i)){
                    nearExit = true;
                }
            }
            if(!nearExit){ // If there isn't any, increase the distance
                distance++;
                //Console.Error.WriteLine("Distance: "+ distance);
            }
            if(currentLocation == finish){ // When we find the exit, we're done
                foundExit = true;
            }
            foreach(int i in nodes[currentLocation]){ // BFS add nearby nodes to queue with current distance
                if(!visited.Contains(i) && !exits.Contains(i)){
                    int[] tempLoad = new int[2];
                    tempLoad[0] = i;
                    tempLoad[1] = distance;
                    //Console.Error.WriteLine("Add to Queue: " + i);
                    q.Enqueue(tempLoad);
                }
            }
        }
        return distance;
    }
}
