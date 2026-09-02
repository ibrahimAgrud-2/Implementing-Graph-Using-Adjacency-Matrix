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


            //Bir Node'un Outdegree'si almak için matriste o node'un bulunduğu satıra bakarak bulabilrisn. 
            //Sıfır dışındaki tüm değerler +1 olarak hesaplanır. Yani 0 kenar yok demek
            public int GetOutdegree(string node)
            {
                byte counter=0;
                if(Vertices.Contains(node))
                {
                for (int i = 0; i <Vertices.Count; i++)
                {
                    if(adjacencyMatrix[Vertices.IndexOf(node),i]!=0)
                        {
                            counter++;
                        }
                }
                }
                return counter;
                
            }

            //Bir Node'un İndegree'si almak için matriste o node'un bulunduğu kolona bakarak bulabilrisn. 
            //Sıfır dışındaki tüm değerler +1 olarak hesaplanır. Yani 0 kenar yok demek

             public int GetIntdegree(string node)
            {
                int counter=0;
                int ColumnIndex=Vertices.IndexOf(node);
                if(Vertices.Contains(node))
                {
                for (int i = 0; i <Vertices.Count; i++)
                {
                    if(adjacencyMatrix[i,ColumnIndex]!=0)
                        {
                            counter++;
                        }
                }
                }
                return counter;
                
            }


            public bool NodesHaveConnection(string node1,string node2)
            {
                int columnIndex=Vertices.IndexOf(node1);
                int rowIndex=Vertices.IndexOf(node1);
               
               //Eğer listede olmayan bir node verilerise yine false dönsün
               //yoksa indexOf -1 döner ve  out of range hatası alırısz
                if(columnIndex==-1||rowIndex!=-1)
                {
                    return false;
                }
                return adjacencyMatrix[columnIndex,rowIndex]!=0;
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

            //graph2.DisplayMatix("Matrix Example 2 (directed Graph)");

            System.Console.WriteLine("in Degree For Node D is: "+graph2.GetIntdegree("D"));
            System.Console.WriteLine("Out Degree For Node D is: "+graph2.GetOutdegree("D"));
         
            System.Console.WriteLine("-------------------------------------");
            //example2
         Graph graph3=new Graph(vertices,Graph.GraphDirectionType.eUndirected);
            
            graph3.AddEdge("A","B",5);
            graph3.AddEdge("A","C",3);
            graph3.AddEdge("B","D",12);
            graph3.AddEdge("C","D",10);
            graph3.AddEdge("B","E",2);
            graph3.AddEdge("D","E",7);

          //  graph3.DisplayMatix("Matrix Example 3 (wieghted undirected Graph)");


            //System.Console.WriteLine(graph3.NodesHaveConnection("A","B"));
System.Console.WriteLine(graph3.getIndex());

        }
    }
}