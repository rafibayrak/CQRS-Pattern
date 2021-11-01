using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorProject.CommandQueries.AuthQueries
{
    public class SignOut : IRequest<bool>
    {
    }
}
