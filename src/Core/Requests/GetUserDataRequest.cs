using Core.Models;
using MediatR;

namespace Core.Requests
{
    public class GetUserDataRequest : IRequest<UserData>
    {
        public GetUserDataRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}