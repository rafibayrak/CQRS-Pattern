using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Data.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
