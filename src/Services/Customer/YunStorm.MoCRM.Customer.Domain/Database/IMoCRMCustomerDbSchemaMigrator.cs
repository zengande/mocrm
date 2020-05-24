using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YunStorm.MoCRM.Customer.Database
{
    public interface IMoCRMCustomerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
