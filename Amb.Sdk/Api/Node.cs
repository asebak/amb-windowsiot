using Amb.Sdk.Model;

namespace Amb.Sdk.Api
{
    public class Node
    {
        private readonly IRequest _request;

        public Node(IRequest request)
        {
            _request = request;
        }

        public NodeInfo Information()
        {
            return _request.GetRequest<NodeInfo>("nodeinfo");
        }
    }
}
