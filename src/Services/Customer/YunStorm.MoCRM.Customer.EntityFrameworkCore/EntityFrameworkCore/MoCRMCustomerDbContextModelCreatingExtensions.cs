using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace YunStorm.MoCRM.Customer.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using YunStorm.MoCRM.Customer.Customers;
    public static class MoCRMCustomerDbContextModelCreatingExtensions
    {
        public static void ConfigureCustomerModels(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            ConfigureCustomerEntity(builder.Entity<Customer>());
            ConfigureCustomerLevelEntity(builder.Entity<CustomerLevel>());
            ConfigureContactEntity(builder.Entity<Contact>());
            ConfigureContactRoleEntity(builder.Entity<ContactRole>());
        }

        private static void ConfigureContactRoleEntity(EntityTypeBuilder<ContactRole> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(MoCRMCustomerDbContext.DbTablePrefix + "contact_roles", MoCRMCustomerDbContext.DbSchema);
            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            entityTypeBuilder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            entityTypeBuilder.Property(o => o.DisplayName)
                .HasMaxLength(200)
                .IsUnicode()
                .IsRequired();
        }

        private static void ConfigureContactEntity(EntityTypeBuilder<Contact> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(MoCRMCustomerDbContext.DbTablePrefix + "contacts", MoCRMCustomerDbContext.DbSchema);

            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property<long>("CustomerId")
                .IsRequired();

            entityTypeBuilder.Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            entityTypeBuilder.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(50);

            entityTypeBuilder.Property(e => e.Position)
                .IsRequired(false)
                .HasMaxLength(100);

            entityTypeBuilder.Property<int>("ContactRoleId")
                .IsRequired(true);

            entityTypeBuilder.HasOne(e => e.ContactRole)
                .WithMany()
                .HasForeignKey("ContactRoleId");
        }

        private static void ConfigureCustomerLevelEntity(EntityTypeBuilder<CustomerLevel> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(MoCRMCustomerDbContext.DbTablePrefix + "customer_levels", MoCRMCustomerDbContext.DbSchema);
            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            entityTypeBuilder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            entityTypeBuilder.Property(o => o.DisplayName)
                .HasMaxLength(200)
                .IsUnicode()
                .IsRequired();
        }

        private static void ConfigureCustomerEntity(EntityTypeBuilder<Customer> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(MoCRMCustomerDbContext.DbTablePrefix + "customers", MoCRMCustomerDbContext.DbSchema);
            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();
            entityTypeBuilder.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(50);
            entityTypeBuilder.Property(e => e.Remarks)
                .IsRequired(false);
            entityTypeBuilder.Property(e => e.Address)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(512);
            entityTypeBuilder.Property<int>("CustomerLevelId")
                .IsRequired();

            var navigation = entityTypeBuilder.Metadata.FindNavigation(nameof(Customer.Contacts));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            entityTypeBuilder.HasOne(e => e.CustomerLevel)
                .WithMany()
                .HasForeignKey("CustomerLevelId");
        }
    }
}
