﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpflab2
{
    class PeopleContext : DbContext
    {
        public PeopleContext() : base("MyConnection")
        { 

        }
        public DbSet<Person> Persons { get; set; }
    }
}
