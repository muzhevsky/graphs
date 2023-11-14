using System.Text;
using GraphsCore.Core;

namespace GraphsCore.Writers;

public class ConnectionsMatrixWriter: IGraphWriter
{
    FileWriter _fileWriter;

    public ConnectionsMatrixWriter(string path)
    {
        _fileWriter = new FileWriter(path);
    }
    
    public void Write(Graph graph)
    {
        var vertices = graph.Vertices;
        var resultString = new StringBuilder();
        resultString.Append($"{vertices.Count}\n");
        foreach (var vertice in vertices)
        {
            foreach (var iteratingVertice in vertices)
            {
                var edge = graph.GetEdge(vertice, iteratingVertice);
                if (edge == null)
                {
                    resultString.Append("0 ");
                    continue;
                }
                resultString.Append($"{edge.Weight} ");
            }

            resultString.Append('\n');
        }

        _fileWriter.Write(resultString.ToString());
    }
}