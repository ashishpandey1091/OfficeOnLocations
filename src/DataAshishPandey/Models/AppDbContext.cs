﻿
using Microsoft.Data.Entity;

namespace DataAshishPandey.Models
{

        public class AppDbContext : DbContext
        {

            public DbSet<Location> Locations { get; set; }
            public DbSet<Office> offices { get; set; }
            
        }
    }


