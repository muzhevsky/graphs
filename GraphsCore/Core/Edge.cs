namespace GraphsCore.Core{
    public class Edge
    {
        Vertice _start;
        Vertice _end;
        float _weight;
        
        public Vertice Start => _start;
        public Vertice End => _end;
        public float Weight => _weight;

        public Edge(Vertice start, Vertice end)
        {
            _start = start;
            _end = end;
            _weight = 1;
        }

        public Edge(Vertice start, Vertice end, float weight)
        {
            _start = start;
            _end = end;
            _weight = weight;
        }
    }
}