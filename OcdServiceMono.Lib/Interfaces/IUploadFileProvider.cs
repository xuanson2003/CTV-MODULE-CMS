﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcdServiceMono.Lib.Interfaces
{
    public interface IUploadFileProvider
    {
        string BuildSavePathYYYYMMDD(string savePath);
    }
}
