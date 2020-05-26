using Microsoft.EntityFrameworkCore;
using Volo.Abp;

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
        }
    }
}