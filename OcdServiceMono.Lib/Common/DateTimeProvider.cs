using OcdServiceMono.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Core
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset OffsetNow => DateTimeOffset.Now;
    }
}
