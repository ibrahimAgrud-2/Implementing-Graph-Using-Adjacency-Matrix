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
                //eleman sayısı kadar dizi oluştur. Mesela 3 elemanlı ise 3x3 array
                adjacencyMatrix=new int[vertices.Count,vertices.Count];
                this.Vertices=vertices;
            }

            public void AddEdge(string node1,string node2,int connectionValue)
            {

                
                if(Vertices.Contains(node1)&&Vertices.Contains(node2))
                {
                    if(enGraphDirectionType==GraphDirectionType.enDirected)
                    {
                         adjacencyMatrix[Vertices.IndexOf(node1),Vertices.IndexOf(node2)]=connectionValue;
                    }
                    else
                    {
                         adjacencyMatrix[Vertices.IndexOf(node1),Vertices.IndexOf(node2)]=connectionValue;
                         adjacencyMatrix[Vertices.IndexOf(node2),Vertices.IndexOf(node1)]=connectionValue;
                    }
                }
            } 



            public void DisplayMatix(string title)
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


            List<string>vertices=new List<string>(){"A","B","C","D","E"};

            Graph graph=new Graph(vertices,Graph.GraphDirectionType.eUndirected);
            
            graph.AddEdge("A","B",1);
            graph.AddEdge("A","C",1);
            graph.AddEdge("B","D",1);
            graph.AddEdge("C","D",1);
            graph.AddEdge("B","E",1);
            graph.AddEdge("D","E",1);


            graph.DisplayMatix("Matrix Example 1 (Undirected Graph)");
         

        }
    }
}