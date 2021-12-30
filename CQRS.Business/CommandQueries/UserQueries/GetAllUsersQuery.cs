using CQRS.Data.Dtos;
using CQRS.Data.Models;
using MediatR;
using System;
using System.Linq;

namespace CQRS.Business.CommandQueries.UserQueries
{
    public class GetAllUsersQuery : IRequest<IQueryable<UserDto>>
    {
    }
}
