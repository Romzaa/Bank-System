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
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasOne(b => b.BranchManager)
                   .WithOne(m => m.ManagedBranch)
                   .HasForeignKey<Branch>(b => b.ManagerId)
                   .IsRequired();

            builder.Property(b => b.Code)
                     .HasMaxLength(10)
                     .IsRequired();

            builder.HasIndex(b => b.Code)
                     .IsUnique();

            builder.HasMany(b => b.Accounts)
                   .WithOne(a => a.Branch)
                   .HasForeignKey(a => a.BranchId);

        }
    }
}
