using MediatorProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorProject.CommandRequest
{
    public class CreateUser : IRequest<User>
    {
    }
}
