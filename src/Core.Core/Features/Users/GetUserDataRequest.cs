using Core.Models;
using MediatR;

namespace Core.Features.Users
{
    public class GetUserDataRequest : IRequest<UserData> { }
}