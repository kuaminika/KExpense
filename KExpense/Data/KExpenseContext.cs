using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KExpense.Model;

namespace KExpense.Data
{
    public class KExpenseContext : DbContext
    {
        public KExpenseContext (DbContextOptions<KExpenseContext> options)
            : base(options)
        {
        }

        public DbSet<KExpense.Model.ExpenseModel> ExpenseModel { get; set; }

        public DbSet<KExpense.Model.Orgnanization> Orgnanization { get; set; }
    }
}
