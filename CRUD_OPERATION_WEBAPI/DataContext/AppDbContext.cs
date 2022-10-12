using CRUD_OPERATION_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_OPERATION_WEBAPI.DataContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<ChampCustomer>ChampCustomers { get; set; }

        
    }
}
