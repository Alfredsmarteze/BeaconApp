using BeaconApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeaconApp.Data
{
    public class BeaconContext:DbContext
    {
        public BeaconContext(DbContextOptions options) : base(options) { }

        public DbSet<IBS_Currency> IBS_Currencies { get; set; }

    }
}
