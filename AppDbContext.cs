using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppEmp.Models;

namespace WebAppEmp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }
    }
}
