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
    public class CardConfiguration : IEntityTypeConfiguration<Card>

    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Cards");
            
                 

            builder.HasData(new List<Card>()
            {
                new Card() { ID = 1, CardNumber = "6037697604053527" , Password = "3030" , Balance = 65 ,UserID = 1},
                new Card() { ID = 2, CardNumber = "6219861967053066" , Password = "3030" , Balance = 200 ,UserID = 2 },

            });


        }
    }
}
