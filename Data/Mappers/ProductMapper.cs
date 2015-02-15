using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PizzaDelivery01.Entity;

namespace PizzaDelivery01.Mappers
{
    public class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            this.ToTable("Product");

            this.HasKey(p => p.id);
            this.Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.id).IsRequired();

            this.Property(p => p.name).IsRequired();
            this.Property(p => p.name).HasMaxLength(255);

            this.Property(p => p.description).IsRequired();
            this.Property(p => p.description).HasMaxLength(1000);

            this.Property(p => p.size).IsRequired();
            this.Property(p => p.weight).IsRequired();
            this.Property(p => p.price).IsRequired();
        }
    }
}