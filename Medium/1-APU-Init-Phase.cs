using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        // Parse
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        List<int> nodes = new List<int>();
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            char[] temp = line.ToCharArray();
            for (int j = 0; j< width; j++){
                if(temp[j] == '0'){
                    nodes.Add(j + i*width);
                }
            }
        }
        
        // Solve
        foreach(int node in nodes){
            int x = GetX(node, width);
            int y = GetY(node, width);
            
            // Find the node to the right
            int right = x + 1;
            while(!nodes.Contains(right + y*width) && right % width > 0){
                right++;
            }
            if (right == width){
                right = -1;
            } else {
                right = right + y*width;
            }
            
            // Find the down node
            int down = (y+1)*width + x;
            int i = 1;
            while(!nodes.Contains(down) && down < height*width){
                i++;
                down = (y+i)*width + x;
            }
            if (down>height*width) {
                down = -1;
            }
            
            // Get the xy coords for found nodes
            int rx = -1;
            int ry = -1;
            if(nodes.Contains(right)){
                rx = GetX(right,width);
                ry = GetY(right,width);
            }
            int dx = -1;
            int dy = -1;
            if(nodes.Contains(down)){
                dx = GetX(down,width);
                dy = GetY(down,width);
            }
            Console.WriteLine("{0} {1} {2} {3} {4} {5}",x,y,rx,ry,dx,dy);
            
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        // Three coordinates: a node, its right neighbor, its bottom neighbor
    }
    
    public static int GetX(int index, int w){
        return index % w;
    }
    public static int GetY(int index, int w){
           return (int)(index/w);
    }
}