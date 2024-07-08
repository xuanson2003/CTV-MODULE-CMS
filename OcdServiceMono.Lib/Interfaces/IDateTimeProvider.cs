using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTimeOffset OffsetNow { get; }
    }
}
