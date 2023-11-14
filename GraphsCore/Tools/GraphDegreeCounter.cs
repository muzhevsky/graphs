using GraphsCore.Core;

namespace GraphsCore.Tools;

public partial class GraphDegreeCounter
{
    public static (Vertice, int) GetMaxDegree(Graph graph)
    {
        var degrees = GetDegrees(graph);

        (Vertice, int) max = (null, 0);
        foreach (var pair in degrees)
            if (max.Item2 < pair.Value) max = (pair.Key, pair.Value);

        return max;
    }
    
    public static Dictionary<Vertice, int> GetDegrees(Graph graph)
    {
        var vertices = graph.Vertices;
        var edges = graph.Edges;
        var degrees = new Dictionary<Vertice, int>();
        foreach (var vertice in vertices)
            degrees.Add(vertice, 0);

        foreach (var edge in edges)
        {
            degrees[edge.Start]++;
            degrees[edge.End]++;
        }

        return degrees;
    }
    
    
    public static (Vertice, int) GetMinDegree(Graph graph)
    {
        var degrees = GetDegrees(graph);

        (Vertice, int) min = (null, int.MaxValue);
        foreach (var pair in degrees)
            if (min.Item2 > pair.Value) min = (pair.Key, pair.Value);

        return min;
    }
}