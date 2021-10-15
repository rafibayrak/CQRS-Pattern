using MediatorProject.Dtos;
using MediatorProject.Models;
using MediatR;
using System;
using System.Linq;

namespace MediatorProject.CommandQueries
{
    public class GetAllUsersQuery : IRequest<IQueryable<UserDto>>
    {
    }
}
