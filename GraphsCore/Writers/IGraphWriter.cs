using GraphsCore.Core;

namespace GraphsCSharp.Writers;

public interface IGraphWriter
{
    void Write(Graph graph);
}