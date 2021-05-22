using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_api.DBContext
{
    public class ComputerWorkshopDBContext : DbContext
    {
        public ComputerWorkshopDBContext(DbContextOptions<ComputerWorkshopDBContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}
