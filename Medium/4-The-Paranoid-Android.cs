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
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        Dictionary<int,int> e = new Dictionary<int,int>();
        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
            int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
            e.Add(elevatorFloor,elevatorPos);
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            Console.Error.WriteLine("floor " + cloneFloor + " pos " + clonePos + " direction " + direction);
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            bool block = false;
            if(direction == "RIGHT"){ // If the leader is moving right
                if(e.ContainsKey(cloneFloor))  // If there is an elevator on this floor
                {
                    if(e[cloneFloor] < clonePos){ // and it's to the left, block
                        block = true;
                    }
                } else if (exitPos < clonePos){ // If the exit is to the left, block
                    block = true;
                }
                if(clonePos + 1 == width){ // Safety check for wall collisions
                    block = true;
                }
            } else { // Moving left
                if(e.ContainsKey(cloneFloor)) // If there is an elevator on this floor
                {
                    if(e[cloneFloor] > clonePos){ // and it's to the right, block
                        block = true;
                    }
                } else if (exitPos > clonePos){ // If the exit is to the right, block
                    block = true;
                }
                if(clonePos - 1 == -1){ // Safety check for wall collisions
                    block = true;
                }
            }
            if(block){
                Console.WriteLine("BLOCK");
            } else {
                Console.WriteLine("WAIT"); // action: WAIT or BLOCK
            }
        }
    }
}