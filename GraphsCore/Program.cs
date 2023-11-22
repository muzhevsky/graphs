using GraphsCore.Core;
using GraphsCore.Readers;
using GraphsCore.Tools;
using GraphsCore.Writers;

namespace GraphsCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new EdgeListReader("E:\\test1.txt");
            var graph = reader.Read();
            Console.WriteLine(graph.EdgeCount);
            graph.AddVertice(new Vertice(10));

            var max = GraphDegreeCounter.GetMaxDegree(graph);
            var min = GraphDegreeCounter.GetMinDegree(graph);
            Console.WriteLine($"maxIndex: {max.Item1.Index}, maxDegree: {max.Item2}");
            Console.WriteLine($"minIndex: {min.Item1.Index}, minDegree: {min.Item2}");
            
            graph.AddEdge(new Edge(graph[1], graph[10], 999));
            BellmanFord.GetAllLenghts(graph, graph[1]);
            graph.RemoveEdge(graph.GetEdge(graph[2], graph[4]));
            graph.RemoveVertice(graph[3]);
            new ConnectionsMatrixWriter("E:\\newtest.txt").Write(graph);
            new EdgeListWriter("E:\\newtestEdges.txt").Write(graph);
            
            
            Obfuscator.Obfuscator.Test(typeof(Program).Assembly, args[0]);
            Console.Read();
        }
    }
}