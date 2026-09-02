using System;
using System.Collections.Generic;

namespace BinaryTreeImplementation
{

    class Program
    {

        public class Graph
        {
            
            public enum GraphDirectionType {enDirected=1,eUndirected=2}; 

            public GraphDirectionType enGraphDirectionType;


            int[,] adjacencyMatrix;
            List<string> Vertices;
            public Graph(List<string> vertices,GraphDirectionType enGraphDirectionType)
            {
                adjacencyMatrix=new int[vertices.Count,vertices.Count];
                this.Vertices=new List<string>(vertices);
            }

            public void AddEdge(string node1,string node2,int connectionValue)
            {
                if(Vertices.Contains(node1)&&Vertices.Contains(node2))
                {
                     adjacencyMatrix[Vertices.IndexOf(node1),Vertices.IndexOf(node2)]=connectionValue;
                }
            } 



            public void DisplayMatix()
            {
               for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                {
                    for (int k = 0; k < adjacencyMatrix.GetLength(1); k++)
                    {
                        System.Console.Write(adjacencyMatrix[i,k]+"  ");
                    }
                    System.Console.WriteLine();
                }
            }


        }


        static void Main(string[] args)
        {


            List<string>vertices=new List<string>()
            {
              "A","B","C" 
            };

            Graph graph=new Graph(vertices,Graph.GraphDirectionType.enDirected);
            
            graph.AddEdge("A","B",1);


            graph.DisplayMatix();
         

        }
    }
}