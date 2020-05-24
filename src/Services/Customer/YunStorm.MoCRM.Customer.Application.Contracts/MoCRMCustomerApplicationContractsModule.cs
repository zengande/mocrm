using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace YunStorm.MoCRM.Customer
{
    [DependsOn(
        typeof(MoCRMCustomerDomainSharedModule)
        )]
    public class MoCRMCustomerApplicationContractsModule :
        AbpModule
    {
    }
}
