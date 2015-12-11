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
        // State list - map, direction, location, breaker, priorities - if adding to it with a duplicate state, LOOP
        List<State> states = new List<State>();
        Queue<char> dirQueue = new Queue<char>();
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int C = int.Parse(inputs[1]);
        int loops = 0; // Count number of times we're adding a duplicate state
        int start = 0; // Initial position of Bender
        int end = 0; // Suicide booth location
        int tele1 = -1;
        int tele2 = -1;
        bool loopExists = false;
        bool breaker = false;
        bool inverter = false;
        char lastDirection = 'S'; // Always start moving South
        char nextDirection = lastDirection;
        
        // Store current map
        char[] map = new char[L*C];
        for (int i = 0; i < L; i++)
        {
            char[] row = Console.ReadLine().ToCharArray();
            for (int j = 0; j < C; j++){
                map[i*C+j] = row[j];
                if (row[j] == '@'){
                    start = i*C+j;
                }
                if (row[j] == '$'){
                    end = i*C+j;
                }
                if (row[j] == 'T'){
                    if(tele1 == -1){
                        tele1 = i*C+j;
                    } else { 
                        tele2 = i*C+j;
                    }
                }
            }
        }
        
        // Traverse map and store states
        int currentLocation = start;
        int lastLocation = start;
        states.Add(new State(map,lastDirection,nextDirection,currentLocation,lastLocation,breaker,inverter)); // initial state
        while(currentLocation != end && !loopExists){
            
            // Set move order
            char[] moveOrder = new char[]{'S','E','N','W'};
            if (inverter){
                moveOrder = new char[]{'W','N','E','S'};
            }
            
            // Find neighboring positions. Should never be near map
            // edge (array out of bounds) because # borders the map
            int x = currentLocation % C;
            int y = (int) currentLocation/C;
            int west = x - 1 + y*C;
            int north = x + (y-1)*C;
            int east  = x + 1 + y*C;
            int south =  x + (y+1)*C;
            
            bool canMove = false;
            int i = 0;
            char nextLoc = ' ';
                
            // Select next location
            nextDirection = lastDirection;
            while(!canMove){ // Assuming Bender never gets trapped in one tile.
                if(nextDirection == 'S'){
                    nextLoc = map[south];
                    currentLocation = south;
                } else if (nextDirection == 'E'){
                    nextLoc = map[east];
                    currentLocation = east;
                } else if (nextDirection == 'W'){
                    nextLoc = map[west];
                    currentLocation = west;
                } else {
                    nextLoc = map[north];
                    currentLocation = north;
                }
                switch (nextLoc){ // Follow tile rules
                    case ' ' :
                        goto default;
                    case 'N' :
                        lastDirection = 'N';
                        canMove = true;
                        break;
                    case 'E' :
                        lastDirection = 'E';
                        canMove = true;
                        break;
                    case 'S' :
                        lastDirection = 'S';
                        canMove = true;
                        break;
                    case 'W' :
                        lastDirection = 'W';
                        canMove = true;
                        break;
                    case '#' :
                        break;
                    case 'X' :
                        if (breaker){
                            map[currentLocation] = ' ';
                            goto default;
                        }
                        break;
                    case 'B' :
                        breaker = !breaker;
                        goto default;
                    case 'I' :
                        inverter = !inverter;
                        goto default;
                    case '$' :
                        goto default;
                    case '@' :
                        goto default;
                    case 'T' :
                        if(currentLocation == tele1){
                            currentLocation = tele2;
                        } else {
                            currentLocation = tele1;
                        }
                        goto default;
                    default :
                        canMove = true;
                        lastDirection = nextDirection;
                        break;
                }
                if(!canMove){ // If you can't go there, try the next move.
                    nextDirection = moveOrder[i];
                    i++;
                }
            }
            //Console.Error.Write("Location: " + currentLocation + " i: " + i + " LastDir: " + lastDirection + " NextDir: " + nextDirection);
            //Console.Error.WriteLine();
            // Save state and check for loop
            foreach(State s in states){
                if(new string(s.Map).Equals(new string(map)) && s.LastLocation == lastLocation && s.LastDirection == lastDirection && s.NextDirection == nextDirection && s.Location == currentLocation && s.Breaker == breaker && s.Inverter == inverter){
                    loops++;
                    if(loops>100){
                        loopExists = true;
                    }
                }
            }
            states.Add(new State(map,lastDirection,nextDirection,currentLocation,lastLocation,breaker,inverter));
            lastLocation = currentLocation;
        }
        //Console.Error.WriteLine(loops+" "+ states.Count());
        
        // Read back states
        bool initial = true;
        if(loopExists){
            Console.WriteLine("LOOP");
        } else {
            foreach (State s in states){
                if(!initial){
                    switch (s.NextDirection){
                        case 'S':
                            Console.WriteLine("SOUTH");
                            break;
                        case 'N':
                            Console.WriteLine("NORTH");
                            break;
                        case 'E':
                            Console.WriteLine("EAST");
                            break;
                        case 'W':
                            Console.WriteLine("WEST");
                            break;
                    }
                } else {
                    initial = false;
                }
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}


// An instance of all the current variables
class State
{
    public char[] Map {get; set;}
    public char LastDirection {get; set;}
    public char NextDirection {get; set;}
    public int Location {get; set;}
    public int LastLocation {get; set;}
    public bool Breaker {get; set;}
    public bool Inverter {get; set;}
    public State(char[] map, char lastDirection, char nextDirection, int location, int lastLocation, bool breaker, bool inverter){
        Map = map;
        LastDirection = lastDirection;
        NextDirection = nextDirection;
        Location = location;
        LastLocation = lastLocation;
        Breaker = breaker;
        Inverter = inverter;
    }
}