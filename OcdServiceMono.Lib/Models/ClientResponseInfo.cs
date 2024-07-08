﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Models
{
    public class ClientResponseInfo
    {        
        public bool IsStatusCode { get; set; }
        public string StatusCode { get; set; }
        public string Content { get; set; }
    }
}
