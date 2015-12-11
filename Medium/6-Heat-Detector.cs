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
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);
        // Guess boundries
        int topGuess = 0;
        int bottomGuess = 0;
        int rightGuess = 0;
        int leftGuess = 0;
        int topInit = 0;
        int bottomInit = 0;
        int rightInit = 0;
        int leftInit = 0;
        bool initial = true;
        // game loop
        while (true)
        {
            string BOMBDIR = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            switch (BOMBDIR){
                case "U" :
                    // If in last valid spot, reset
                    if(topInit == y && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = 0;
                        topInit = 0;
                        bottomGuess = y;
                        bottomInit = y;
                        leftGuess = x;
                        leftInit = x;
                        rightGuess = x;
                        rightInit = x;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = topInit;
                        bottomGuess = y;
                        leftGuess = x;
                        rightGuess = x;
                        // Truncate outside of guess locations from initial locations
                        bottomInit = y;
                        leftInit = x;
                        rightInit = x;
                    }
                    break;
                case "UR" :
                    // If in last valid spot, reset
                    if((topInit == y && rightInit == x) && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = 0;
                        topInit = 0;
                        bottomGuess = y;
                        bottomInit = y;
                        leftGuess = x;
                        leftInit = x;
                        rightGuess = W;
                        rightInit = W;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = topInit;
                        bottomGuess = y;
                        leftGuess = x;
                        rightGuess = rightInit;
                        // Truncate outside of guess locations from initial locations
                        bottomInit = y;
                        leftInit = x;
                    }
                    break;
                case "R" :
                    // If in last valid spot, reset
                    if(rightInit == x && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = y;
                        topInit = y;
                        bottomGuess = y;
                        bottomInit = y;
                        leftGuess = x;
                        leftInit = x;
                        rightGuess = W;
                        rightInit = W;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = y;
                        bottomGuess = y;
                        leftGuess = x;
                        rightGuess = rightInit;
                        // Truncate outside of guess locations from initial locations
                        topInit = y;
                        bottomInit = y;
                        leftInit = x;
                    }
                    break;  
                case "DR" :
                    // If in last valid spot, reset
                    if((bottomInit == y && rightInit == x) && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = y;
                        topInit = y;
                        bottomGuess = H;
                        bottomInit = H;
                        leftGuess = x;
                        leftInit = x;
                        rightGuess = W;
                        rightInit = W;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = y;
                        bottomGuess = bottomInit;
                        leftGuess = x;
                        rightGuess = rightInit;
                        // Truncate outside of guess locations from initial locations
                        topInit = y;
                        leftInit = x;
                    }
                    break;
                case "D" :
                    // If in last valid spot, reset
                    if(bottomInit == y && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = y;
                        topInit = y;
                        bottomGuess = H;
                        bottomInit = H;
                        leftGuess = x;
                        leftInit = x;
                        rightGuess = x;
                        rightInit = x;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = y;
                        bottomGuess = bottomInit;
                        leftGuess = x;
                        rightGuess = x;
                        // Truncate outside of guess locations from initial locations
                        topInit = y;
                        leftInit = x;
                        rightInit = x;
                    }
                    break;
                case "DL" :
                    // If in last valid spot, reset
                    if((bottomInit == y && leftInit == x) && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = y;
                        topInit = y;
                        bottomGuess = H;
                        bottomInit = H;
                        leftGuess = 0;
                        leftInit = 0;
                        rightGuess = x;
                        rightInit = x;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = y;
                        bottomGuess = bottomInit;
                        leftGuess = leftInit;
                        rightGuess = x;
                        // Truncate outside of guess locations from initial locations
                        topInit = y;
                        rightInit = x;
                    }
                    break;
                case "L" :
                    // If in last valid spot, reset
                    if(leftInit == x && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = y;
                        topInit = y;
                        bottomGuess = y;
                        bottomInit = y;
                        leftGuess = 0;
                        leftInit = 0;
                        rightGuess = x;
                        rightInit = x;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = y;
                        bottomGuess = y;
                        leftGuess = leftInit;
                        rightGuess = x;
                        // Truncate outside of guess locations from initial locations
                        topInit = y;
                        bottomInit = y;
                        rightInit = x;
                    }
                    break;
                case "UL" :
                    // If in last valid spot, reset
                    if((topInit == y && leftInit == x) && !initial){
                        initial = true;
                    }
                    // Set initial location
                    if(initial){
                        topGuess = 0;
                        topInit = 0;
                        bottomGuess = y;
                        bottomInit = y;
                        leftGuess = 0;
                        leftInit = 0;
                        rightGuess = x;
                        rightInit = x;
                        initial = false;
                    } else {
                        // Set guess
                        topGuess = topInit;
                        bottomGuess = y;
                        leftGuess = leftInit;
                        rightGuess = x;
                        // Truncate outside of guess locations from initial locations
                        bottomInit = y;
                        rightInit = x;
                    }
                    break;
            }
            
            // Go to the center point of the current guess rectangle
            y = (bottomGuess + topGuess)/2;
            x = (rightGuess + leftGuess)/2;
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(x+" "+y); // the location of the next window Batman should jump to.
        }
    }
}