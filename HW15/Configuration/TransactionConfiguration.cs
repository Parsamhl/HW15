using HW15.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionsId);
            builder.ToTable("Transaction");

            builder.HasOne(a => a.SourceCard)
                .WithMany(a => a.SentTransaction)
                .HasForeignKey(a => a.SourceCardNumberId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.DestinationCard)
                .WithMany(a => a.RecivedTransaction)
                .HasForeignKey(a => a.DestinationCardNumberID)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
