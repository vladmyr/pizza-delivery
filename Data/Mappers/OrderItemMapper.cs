using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PizzaDelivery01.Entity;

namespace PizzaDelivery01.Mappers
{
    public class OrderItemMapper : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMapper()
        {
            this.ToTable("OrderItem");

            this.HasKey(o => o.id);
            this.Property(o => o.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(o => o.id).IsRequired();

            this.Property(o => o.orderId).IsRequired();
            this.Property(o => o.productId).IsRequired();
            this.Property(o => o.quantity).IsRequired();
        }
    }
}