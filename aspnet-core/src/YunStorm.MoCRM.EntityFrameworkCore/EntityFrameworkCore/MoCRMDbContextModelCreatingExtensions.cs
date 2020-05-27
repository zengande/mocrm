using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using YunStorm.MoCRM.Customers;

namespace YunStorm.MoCRM.EntityFrameworkCore
{
    public static class MoCRMDbContextModelCreatingExtensions
    {
        public static void ConfigureMoCRM(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MoCRMConsts.DbTablePrefix + "YourEntities", MoCRMConsts.DbSchema);

            //    //...
            //});

            builder.Entity<Customer>(b =>
            {
                b.ToTable(MoCRMConsts.DbTablePrefix + "Customers", MoCRMConsts.DbSchema);

                b.Ignore(e => e.ExtraProperties);

                b.HasKey(e => e.Id);

                b.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                b.Property(e => e.PhoneNumber)
                    .HasMaxLength(50);

                b.Property(e => e.EmailAddress)
                    .HasMaxLength(100);

                b.Property(e => e.CreatedAt);

                b.Property(e => e.WebSite)
                    .HasMaxLength(200);

                b.Property(e => e.Remarks);

                var navigation = b.Metadata.FindNavigation(nameof(Customer.Contacts));
                navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Entity<Contact>(b =>
            {
                b.ToTable(MoCRMConsts.DbTablePrefix + "Contacts", MoCRMConsts.DbSchema);

                b.HasKey(e => e.Id);

                b.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                b.Property(e => e.Department)
                    .HasMaxLength(200);

                b.Property(e => e.PhoneNumber)
                    .HasMaxLength(50);

                b.Property(e => e.EmailAddress)
                    .HasMaxLength(100);

                b.Property(e => e.Birthday);

                b.Property(e => e.Gender);

                b.Property(e => e.Position)
                    .HasMaxLength(200)
                    .IsUnicode();

                b.Property(e => e.CustomerId)
                    .IsRequired();
            });
        }
    }
}