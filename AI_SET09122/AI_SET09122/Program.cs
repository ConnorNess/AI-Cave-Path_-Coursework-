using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_SET09122
{
    class Program
    {
        static void Main(string[] args)
        {
            //read in caves
            string syspath = args[1] + "/" + args[0];
            string caves = System.IO.File.ReadAllText(syspath+".cav");

            //cave variables
            var cavesList = caves.Split(',').Select(Int32.Parse).ToList();
            int cavesNo = (cavesList[0]);
            List<Node> routesList = new List<Node>();
            List<int> connectionList = new List<int>();

            //cave list
            var nodeList = new List<Node>();
            int[,] caveRoutes = new int[cavesNo, cavesNo];
            Node startNode = new Node();
            Node finalNode = new Node();

            //Loop counter
            int cavecounter = 0;
            int caveid = 1;

            //initilised the class
            Path pathClass = new Path();

            //Loop to pull connection matrix from the supplied file
            for (int i = (cavesNo * 2) + 1; i < cavesList.Count(); i++)
            {
                connectionList.Add(cavesList[i]);
            }

            //Adds caves to a node class and assigns the coords
            for (int i = 1; i <= cavesNo * 2; i = i + 2)
            {
                Node thisNode = new Node();
                thisNode.X_coord = cavesList[i];
                thisNode.Y_coord = cavesList[i + 1];
                thisNode.caveid = caveid;
                caveid++;
                nodeList.Add(thisNode);
                Console.WriteLine(thisNode.X_coord + "," + thisNode.Y_coord);
                //starting position check  
                if (i == 1) { startNode = thisNode; }
                //end position check
                if (i == (cavesNo*2)-1) { finalNode = thisNode; }
            }

            //Loop to fill in matrix
            for (int i = 0; i < cavesNo; i++)
            {
                for (int j = 0; j < cavesNo; j++)
                {
                    caveRoutes[i, j] = connectionList[cavecounter];
                    //Console.WriteLine(caveRoutes[i, j]);
                    cavecounter++;
                }
            }

            routesList = pathClass.FoundPath(caveRoutes, nodeList, startNode, cavesNo, finalNode);
            routesList.Insert(0, startNode);
            TextWriter tw = new StreamWriter(@syspath+".csn");
            string routeOutput = "";
            foreach(Node thisNode in routesList)
            {
                routeOutput += thisNode.caveid + " ";
            }
            tw.WriteLine(routeOutput);
            tw.Close();
            Console.ReadLine();
        }
    }
}
