using BankTransactionWithjQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTransactionWithjQuery.DbContext
{
    public class OnlineBankDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TransactionModel> Transactions { get; set; }

        public OnlineBankDbContext(DbContextOptions<OnlineBankDbContext> options)
            :base(options)
        {}
    }
}
