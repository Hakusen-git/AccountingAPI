using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingAPI.Models
{
    public class ApplicationDatabase : DbContext
    {
        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }


      

    }
}
