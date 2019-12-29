using KocFinans.CreditCalculation.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Data
{
    public class CreditCalculationDBContext : DbContext
    {
        public CreditCalculationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<CustomerCreditInfo> CustomerInfo { get; set; }
    }
}
