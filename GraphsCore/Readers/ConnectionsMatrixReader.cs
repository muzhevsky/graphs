using System;
using System.IO;
using GraphsCore.Core;
using GraphsCSharp.Core;
using Edge = GraphsCore.Core.Edge;

namespace GraphsCSharp.Readers
{
    public class ConnectionsMatrixReader : IGraphReader
    {
        FileReader _fileReader;

        public ConnectionsMatrixReader(string path)
        {
            _fileReader = new FileReader(path);
        }
        
        public Graph Read()
        {
            var length = int.Parse(_fileReader.ReadLine());
            var str = _fileReader.ReadToTheEnd();
            var lines = str.Split('\n');
            var graph = new Graph();
            var weights = new float[length, length];
            for (var i = 1; i < length; i++)
            {
                var line = lines[i].Split(' ');
                for (var j = 0; j < length; j++)
                {
                    if (i - 1 == j) continue;
                    weights[i - 1 , j] = Convert.ToInt32(line[j]);
                }
            }

            for (var i = 0; i < length; i++)
            {
                graph.AddVertice(new Vertice(i));
            }

            var vertices = graph.Vertices;

            foreach (var vertice in vertices)
            {
                foreach (var iteratingVertice in vertices)
                {
                    var i1 = vertice.Index;
                    var i2 = iteratingVertice.Index;
                    if (weights[i1, i2] == 0) continue;
                    if (graph.HasEdge(graph[i1], graph[i2])) continue;
                    var edge = new Edge(graph[i1], graph[i2], weights[i1, i2]);
                    graph.AddEdge(edge);
                }
            }

            return graph;
        }
    }
}