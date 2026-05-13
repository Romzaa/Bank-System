using Bank_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Configurations
{
    internal class AccConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountType).HasConversion<string>();
            builder.Property(c => c.OpeningDate).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.CurrentBalance).HasPrecision(18, 2);

        }
    }
}
