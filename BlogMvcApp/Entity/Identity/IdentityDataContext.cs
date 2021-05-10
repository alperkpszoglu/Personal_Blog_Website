﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Identity
{
    public class IdentityDataContext: IdentityDbContext<IdentityUser>
    {
        public IdentityDataContext():base("BlogDb")
        {

        }
    }
}