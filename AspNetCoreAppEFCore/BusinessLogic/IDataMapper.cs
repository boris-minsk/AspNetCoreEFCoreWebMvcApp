﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public interface IDataMapper
    {
        DataModel MapLine(string line);
    }
}
