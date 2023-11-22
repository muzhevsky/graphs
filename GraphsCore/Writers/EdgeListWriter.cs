using System.Text;
using GraphsCore.Core;

namespace GraphsCore.Writers;

public class EdgeListWriter: IGraphWriter
{
    FileWriter _fileWriter;

    public EdgeListWriter(string path)
    {
        _fileWriter = new FileWriter(path);
    }
    
    public void Write(Graph graph)
    {
        var edges = graph.Edges;
        var resultString = new StringBuilder();
        resultString.Append($"{edges.Count}\n");
        foreach (var edge in edges)
            resultString.Append($"{edge.Start.Index} {edge.End.Index} {edge.Weight}\n");

        _fileWriter.Write(resultString.ToString());
    }
}