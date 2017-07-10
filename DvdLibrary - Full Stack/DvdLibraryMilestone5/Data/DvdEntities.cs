using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Data
{
    
        public class DvdEntities : DbContext
        {
            public DvdEntities() : base("dvdLibrary")
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
            public DbSet<Dvd> Dvds { get; set; }
            public DbSet<Rating> Ratings { get; set; }
        }
    
}