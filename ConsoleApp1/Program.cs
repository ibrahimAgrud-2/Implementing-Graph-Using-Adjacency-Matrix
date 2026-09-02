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
                this.enGraphDirectionType=enGraphDirectionType;
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
           
                System.Console.WriteLine(title);
               for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                {
                   
                    for (int k = 0; k < adjacencyMatrix.GetLength(1); k++)
                    {
                        System.Console.Write(adjacencyMatrix[i,k]+"  ");
                    }
                    System.Console.WriteLine();
                }
            }

            public int GetIndegree(string node)
            {
                byte counter=0;
                if(Vertices.Contains(node))
                {
                    for (int i = 0; i < ; i++)
                {
                    
                }
                }
                
            }

        }


        static void Main(string[] args)
        {


            List<string>vertices=new List<string>(){"A","B","C","D","E"};
            
            
            //example1
            Graph graph1=new Graph(vertices,Graph.GraphDirectionType.eUndirected);
            
            graph1.AddEdge("A","B",1);
            graph1.AddEdge("A","C",1);
            graph1.AddEdge("B","D",1);
            graph1.AddEdge("C","D",1);
            graph1.AddEdge("B","E",1);
            graph1.AddEdge("D","E",1);

            //graph1.DisplayMatix("Matrix Example 1 (Undirected Graph)");
         


            System.Console.WriteLine("-------------------------------------");
            //example2
         Graph graph2=new Graph(vertices,Graph.GraphDirectionType.enDirected);
            
            graph2.AddEdge("A","A",1);
            graph2.AddEdge("A","B",1);
            graph2.AddEdge("A","C",1);
            graph2.AddEdge("B","E",1);
            graph2.AddEdge("D","B",1);
            graph2.AddEdge("D","C",1);
            graph2.AddEdge("D","E",1);

            graph2.DisplayMatix("Matrix Example 2 (directed Graph)");


  
         


        }
    }
}