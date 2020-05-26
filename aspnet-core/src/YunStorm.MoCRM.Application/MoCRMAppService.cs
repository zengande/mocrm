using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.Localization;
using Volo.Abp.Application.Services;

namespace YunStorm.MoCRM
{
    /* Inherit your application services from this class.
     */
    public abstract class MoCRMAppService : ApplicationService
    {
        protected MoCRMAppService()
        {
            LocalizationResource = typeof(MoCRMResource);
        }
    }
}
