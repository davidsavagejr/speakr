using MediatR;
using Models;

namespace Core.Features.Talks
{
    public class GetTalkRequest : IRequest<Talk>
    {
        public GetTalkRequest(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}