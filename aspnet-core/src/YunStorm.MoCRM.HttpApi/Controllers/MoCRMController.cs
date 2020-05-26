using YunStorm.MoCRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace YunStorm.MoCRM.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MoCRMController : AbpController
    {
        protected MoCRMController()
        {
            LocalizationResource = typeof(MoCRMResource);
        }
    }
}