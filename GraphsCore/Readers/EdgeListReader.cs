using GraphsCore.Core;
using Edge = GraphsCore.Core.Edge;

namespace GraphsCore.Readers
{
    public class EdgeListReader : IGraphReader
    {
        FileReader _fileReader;

        public EdgeListReader(string path)
        {
            _fileReader = new FileReader(path);
        }

        public Graph Read()
        {
            var length = int.Parse(_fileReader.ReadLine());
            var str = _fileReader.ReadToTheEnd();
            var lines = str.Split('\n');
            var graph = new Graph();

            for (var i = 1; i < length + 1; i++)
            {
                var line = lines[i].Split(' ');
                var v1 = Convert.ToInt32(line[0]);
                var v2 = Convert.ToInt32(line[1]);
                if (graph[v1] == null) graph.AddVertice(new Vertice(v1));
                if (graph[v2] == null) graph.AddVertice(new Vertice(v2));
                var weight = Convert.ToSingle(line[2]);
                var edge = new Edge(graph[v1], graph[v2], weight);
                graph.AddEdge(edge);
            }

            return graph;
        }
    }
}