namespace GraphsCore.Core;

public class Graph
{
    LinkedList<Vertice> _vertices;
    LinkedList<Edge> _edges;

    public Graph()
    {
        _vertices = new LinkedList<Vertice>();
        _edges = new LinkedList<Edge>();
    }

    public List<Vertice> Vertices => new(_vertices);
    public List<Edge> Edges => new(_edges);

    public void AddVertice(Vertice? vertice) => _vertices.AddLast(vertice);

    public void RemoveVertice(Vertice vertice)
    {
        _vertices.Remove(vertice);
        var edjesForRemovement = new List<Edge>();
        foreach (var e in _edges)
            if (e.Start == vertice || e.End == vertice) edjesForRemovement.Add(e);

        foreach (var e in edjesForRemovement)
            _edges.Remove(e);
    }
    public void AddEdge(Edge edge) => _edges.AddLast(edge);
    public void RemoveEdge(Edge edge) => _edges.Remove(edge);
    public bool HasEdge(Vertice v1, Vertice v2) => GetEdge(v1, v2) != null;

    public Edge? GetEdge(Vertice v1, Vertice v2) => 
        _edges.FirstOrDefault(edge => edge.Start == v1 && edge.End == v2 || edge.Start == v2 && edge.End == v1);

    public Vertice? this[int i] => _vertices.FirstOrDefault(v => v.Index == i);
    public int VerticeCount => _vertices.Count;
    public int EdgeCount => _edges.Count;
}