using GraphsCore.Core;

namespace GraphsCore.Tools;

public class BellmanFord
{
    public static Dictionary<Vertice, float> GetAllLenghts(Graph graph, Vertice vertice)
    {
        var edges = graph.Edges;
        var invertedEdges = new List<Edge>(edges.Count);
        foreach (var edge in edges)
            invertedEdges.Add(new Edge(edge.End, edge.Start, edge.Weight));

        edges.AddRange(invertedEdges);

        var paths = InitBellmanFord(graph, vertice);
        for (var i = 0; i < graph.VerticeCount - 1; i++)
            foreach (var edge in edges)
                if (paths[edge.End] > paths[edge.Start] + edge.Weight)
                    paths[edge.End] = paths[edge.Start] + edge.Weight;

        return paths;
    }

    public static float GetPathLength(Graph graph, Vertice startVertice, Vertice endVertice)
    {
        return GetAllLenghts(graph, startVertice)[endVertice];
    }
    
    static Dictionary<Vertice, float> InitBellmanFord(Graph graph, Vertice vertice)
    {
        var vertices = graph.Vertices;
        var paths = new Dictionary<Vertice, float>();
        foreach (var v in vertices)
        {
            paths.Add(v, float.MaxValue);
        }

        paths[vertice] = 0;

        return paths;
    }
}