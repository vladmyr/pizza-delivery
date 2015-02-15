using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PizzaDelivery01.Entity;

namespace PizzaDelivery01.Mappers
{
    public class OrderMapper : EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            this.ToTable("Order");

            this.HasKey(o => o.id);
            this.Property(o => o.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.id).IsRequired();

            this.Property(o => o.name).HasMaxLength(255);
            this.Property(o => o.name).IsRequired();

            this.Property(o => o.address).HasMaxLength(1000);
            this.Property(o => o.address).IsRequired();

            this.Property(o => o.phone).HasMaxLength(20);
            this.Property(o => o.phone).IsRequired();

            this.Property(o => o.isCompleted).IsRequired();
            this.Property(o => o.date).IsRequired();
        }
    }
}