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
        int road = int.Parse(Console.ReadLine()); // the length of the road before the gap.
        int gap = int.Parse(Console.ReadLine()); // the length of the gap.
        int platform = int.Parse(Console.ReadLine()); // the length of the landing platform.
        bool jumped = false;
        // game loop
        while (true)
        {
            int speed = int.Parse(Console.ReadLine()); // the motorbike's speed.
            int coordX = int.Parse(Console.ReadLine()); // the position on the road of the motorbike.
            if(jumped){
                Console.WriteLine("SLOW");
            }else{
                if(speed<=gap){
                    Console.WriteLine("SPEED");
                } else if(speed>gap+1){
                    Console.WriteLine("SLOW");
                }else if(coordX+speed-road>=gap){
                    jumped = true;
                    Console.WriteLine("JUMP");
                } else {
                    Console.WriteLine("WAIT");
                }
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

             // A single line containing one of 4 keywords: SPEED, SLOW, JUMP, WAIT.
        }
    }
}