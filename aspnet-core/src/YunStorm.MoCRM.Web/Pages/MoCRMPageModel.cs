using YunStorm.MoCRM.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace YunStorm.MoCRM.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MoCRMPageModel : AbpPageModel
    {
        protected MoCRMPageModel()
        {
            LocalizationResourceType = typeof(MoCRMResource);
        }
    }
}