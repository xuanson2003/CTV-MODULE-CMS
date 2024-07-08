using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Models
{
    public class Dictionary<T>
    {
        public string Key { get; set; }
        public T Value { get;set; }
    }
}
