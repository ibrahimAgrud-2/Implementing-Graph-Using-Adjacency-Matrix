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

            //şimdi normalde hocanın koduna bakmadan dictionary kullanmamıştım. İndexOF ile node'un index'İn ialmıştım
            //Ama hoca dictionary kullanarak bir node'un index'ini anında buldu n(O) ama ben indexOf kullandım ve bu
            //her elemanı tek tek baktığı için maaliyeti o(n) oldu. Normalde dictionary nodesIndex[node1] kullandpığım her 
            //yerde Vertices.IndexOf(node2) kullanıyordum ve bu çok maliyetli
            Dictionary<string,int>nodesIndex;
            public Graph(List<string> vertices,GraphDirectionType enGraphDirectionType)
            {
                //eleman sayısı kadar dizi oluştur. Mesela 3 elemanlı ise 3x3 array
                adjacencyMatrix=new int[vertices.Count,vertices.Count];
                this.Vertices=vertices;
                this.enGraphDirectionType=enGraphDirectionType;

                nodesIndex=new Dictionary<string, int>();

                for (int i = 0; i < vertices.Count; i++)
                {
                    nodesIndex[vertices[i]]=i;
                    //şöyle bir şey oluyor. nodesIndex[A]=2 gibi. Yani key value birleştirmesi yapıyor.
                }
            }

            public void AddEdge(string node1,string node2,int connectionValue)
            {

                
                if(nodesIndex.ContainsKey(node1)&&nodesIndex.ContainsKey(node2))
                {
                     adjacencyMatrix[nodesIndex[node1],nodesIndex[node2]]=connectionValue;
                   
                     if(enGraphDirectionType==GraphDirectionType.eUndirected)
                    {
                          adjacencyMatrix[nodesIndex[node2],nodesIndex[node1]]=connectionValue;
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
                 int rowIndex=nodesIndex[node];
                if(nodesIndex.ContainsKey(node))
                {
                for (int i = 0; i <Vertices.Count; i++)
                {
                    if(adjacencyMatrix[rowIndex,i]!=0)
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
                int ColumnIndex=nodesIndex[node];
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

                    //Eğer node dictionarty'de yoksa exception fırlatmasın
                            if(!nodesIndex.TryGetValue(node1, out int columnIndex) || 
                !nodesIndex.TryGetValue(node2, out int rowIndex))
                {
                    return false;
                }
                return adjacencyMatrix[columnIndex, rowIndex] > 0;
            }


            public void RemoveEdge(string node1,string node2)
            {
                   //Eğer node dictionarty'de yoksa exception fırlatmasın
                if(!nodesIndex.TryGetValue(node1, out int columnIndex) || 
                !nodesIndex.TryGetValue(node2, out int rowIndex))
                {
                    return;
                }
                //eğer matrix undirected olursa hem row hem de kolonu sıfırlaman gekekri. 
                //Mesela Add("A","B",1) olduğunda bunu hem AB hem de BA ikilisi ekleniyor. 
                //Bu yüzden bu şekikde silme yapılmalı. 
                 adjacencyMatrix[columnIndex,rowIndex]=0;
                 adjacencyMatrix[rowIndex,columnIndex]=0;
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
         Graph graph3=new Graph(vertices,Graph.GraphDirectionType.enDirected);
            
            graph3.AddEdge("A","B",5);
            graph3.AddEdge("A","C",3);
            graph3.AddEdge("B","D",12);
            graph3.AddEdge("C","D",10);
            graph3.AddEdge("B","E",2);
            graph3.AddEdge("D","E",7);

            graph3.DisplayMatix("Matrix Example 3 (wieghted directed Graph)");


            
            // System.Console.WriteLine("C and A has Connection: "+graph3.NodesHaveConnection("C","A"));
            // System.Console.WriteLine("A and B has Connection: "+graph3.NodesHaveConnection("A","B"));


            graph3.RemoveEdge("A","B");
            System.Console.WriteLine("After remove");
           graph3.DisplayMatix("Matrix Example 3 (wieghted directed Graph)");

        }
    }
}