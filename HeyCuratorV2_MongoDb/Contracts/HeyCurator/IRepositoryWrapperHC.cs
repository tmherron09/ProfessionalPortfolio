﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Contracts.HeyCurator
{
    public interface IRepositoryWrapperHC
    {
        IEmployeeRepository Employee { get; }
    }
}
