using GraphsCore.Core;
using GraphsCSharp.Core;

namespace GraphsCSharp.Readers
{
    public interface IGraphReader
    {
        Graph Read();
    }
}