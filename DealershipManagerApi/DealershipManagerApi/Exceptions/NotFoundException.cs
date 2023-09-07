using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipManager.Tests.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid entryId)
            : base($"Could not find any entry with the folowing id: {entryId}")
        {
            
        }
    }
}
