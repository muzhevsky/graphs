using GraphsCore.Core;

namespace GraphsCore.Writers;

public interface IGraphWriter
{
    void Write(Graph graph);
}