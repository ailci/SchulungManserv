﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public interface IServiceManager
{
    IQotdService QotdService { get; }
    IAuthorService AuthorService { get; }
}