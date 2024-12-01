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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");
            builder.HasMany(u => u.Cards)
                .WithOne(c => c.owner);


            builder.HasData(new List<User>()
            {
                new User () {Id = 1 , Name = "Ali"} ,
                new User () {Id = 2 , Name =  "Reza" }


            });
        }
    }
}
