﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHubApi.Infrastructure
{
    public class SortTerm
    {
        public string Name { get; set; }

        public string EntityName { get; set; }

        public bool Descending { get; set; }

        public bool Default { get; set; }
    }
}
