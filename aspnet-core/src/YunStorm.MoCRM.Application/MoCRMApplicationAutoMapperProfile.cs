using AutoMapper;
using YunStorm.MoCRM.Customers;

namespace YunStorm.MoCRM
{
    public class MoCRMApplicationAutoMapperProfile : Profile
    {
        public MoCRMApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
