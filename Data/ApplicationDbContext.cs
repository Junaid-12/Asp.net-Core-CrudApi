using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeWebApi.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Employee> employeeMos { get; set; }
    }
}
